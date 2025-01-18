using System.Text;
using System.Text.Json;
using MediatR;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.Application.Commands.PatientCommands;
using ProfilesService.Application.Commands.ReceptionistCommands;
using ProfilesService.Presentation.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProfilesService.Presentation.Services;

public class EventSubscriber
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName = "ProfilesQueue";
    private readonly string _exchangeName = "UserEvents";
    private readonly IServiceProvider _serviceProvider;

    public EventSubscriber(string hostname, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        var factory = new ConnectionFactory() { HostName = hostname };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Fanout);
        _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        _channel.QueueBind(queue: _queueName, exchange: _exchangeName, routingKey: "");
    }

    public void StartListening()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            
            var phoneNumberChangedEvent = JsonSerializer.Deserialize<PhoneNumberChangedEvent>(message);
            if (phoneNumberChangedEvent != null)
            {
                HandleEvent(phoneNumberChangedEvent);
            }
        };

        _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
    }

    private async void HandleEvent(PhoneNumberChangedEvent phoneNumberChangedEvent)
    {
        using var scope = _serviceProvider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        try
        {
            switch (phoneNumberChangedEvent.RoleId)
            {
                case 0: 
                    await mediator.Send(new UpdateDoctorPhoneNumberCommand
                    {
                        UserEmail = phoneNumberChangedEvent.UserEmail,
                        NewPhoneNumber = phoneNumberChangedEvent.NewPhoneNumber
                    });
                    break;

                case 1: 
                    await mediator.Send(new UpdateReceptionistPhoneNumberCommand
                    {
                        UserEmail = phoneNumberChangedEvent.UserEmail,
                        NewPhoneNumber = phoneNumberChangedEvent.NewPhoneNumber
                    });
                    break;

                case 2: 
                    await mediator.Send(new UpdatePatientPhoneNumberCommand
                    {
                        UserEmail = phoneNumberChangedEvent.UserEmail,
                        NewPhoneNumber = phoneNumberChangedEvent.NewPhoneNumber
                    });
                    break;
            }
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public void Close()
    {
        _channel.Close();
        _connection.Close();
    }
}