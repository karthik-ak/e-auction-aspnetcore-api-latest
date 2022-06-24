using System;
using System.Text;
using AutoMapper;
using EAuction.Order.Application.Commands.OrderCreate;
using EventBusRabbitMQ;
using EventBusRabbitMQ.Core;
using EventBusRabbitMQ.Events;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EAuction.Order.WebApi.Consumers
{
    public class EventBusBidCreateConsumer
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EventBusBidCreateConsumer(IRabbitMQPersistentConnection persistentConnection, IMediator mediator, IMapper mapper)
        {
            _persistentConnection = persistentConnection;
            _mediator = mediator;
            _mapper = mapper;
        }

        public void Consume()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.BidCreateQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue:EventBusConstants.BidCreateQueue,autoAck:true,consumer:consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.Span);
            var @event = JsonConvert.DeserializeObject<BidCreateEvent>(message);

            if (e.RoutingKey == EventBusConstants.BidCreateQueue)
            {
                var command = _mapper.Map<BidCreateCommand>(@event);
                command.CreatedAt = DateTime.Now;
                command.BidAmount = @event.BidAmount;

                var result = await _mediator.Send(command);
            }
        }

        public void Disconnect()
        {
            _persistentConnection.Dispose();
        }
    }
}