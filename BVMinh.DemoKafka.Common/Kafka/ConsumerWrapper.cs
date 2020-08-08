using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.Common.Kafka
{
    public class ConsumerWrapper<TKey, TValue> : IDisposable
    {
        private readonly IConsumer<TKey, TValue> _consumer;
        private readonly string _topic;

        public ConsumerWrapper(ConsumerConfig config, string topic)
        {
            _consumer = new ConsumerBuilder<TKey, TValue>(config).Build();
            _topic = topic;
            _consumer.Subscribe(_topic);
        }

        public TValue ReadMessage()
        {
            var message = _consumer.Consume();
            return message.Message.Value;
        }

        public void Dispose()
        {
            _consumer.Dispose();
        }
    }
}
