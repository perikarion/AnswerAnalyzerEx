using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnswerAnalyzerEx.Messages.Commands;
using AnswerAnalyzerEx.Messages.Events;
using CommonDomain;
using System.Collections;
using CommonDomain.Persistence;
using NServiceBus;

namespace AnswerAnalyzerEx.Tests
{
    [TestClass]
    public abstract class CommandTestFixture<TCommand, TCommandHandler, TAggregateRoot>
        where TCommand : class, IDomainCommand
        where TCommandHandler : class, IHandleMessages<TCommand>
        where TAggregateRoot : IAggregate, new()
    {
        protected TAggregateRoot AggregateRoot;
        protected IHandleMessages<TCommand> CommandHandler;
        protected Exception CaughtException;
        protected ICollection PublishedEvents;
        protected IEnumerable<IDomainEvent> PublishedEventsT { get { return PublishedEvents.Cast<IDomainEvent>(); } }
        protected FakeRepository Repository;
        protected virtual void SetupDependencies() { }

        protected virtual IEnumerable<IDomainEvent> Given()
        {
            return new List<IDomainEvent>();
        }

        protected virtual void Finally() { }

        protected abstract TCommand When();

        [TestInitialize]
        public void Setup()
        {
            AggregateRoot = new TAggregateRoot();
            Repository = new FakeRepository(AggregateRoot);
            CaughtException = new ThereWasNoExceptionButOneWasExpectedException();
            foreach (var @event in Given())
            {
                AggregateRoot.ApplyEvent(@event);
            }

            CommandHandler = BuildCommandHandler();
            SetupDependencies();
            try
            {
                CommandHandler.Handle(When());
                if (Repository.SavedAggregate == null)
                    PublishedEvents = AggregateRoot.GetUncommittedEvents();
                else
                    PublishedEvents = Repository.SavedAggregate.GetUncommittedEvents();
            }
            catch (Exception exception)
            {
                CaughtException = exception;
            }
            finally
            {
                Finally();
            }
        }

        private IHandleMessages<TCommand> BuildCommandHandler()
        {
            Func<IRepository> createReposFunc = () => Repository;
            return Activator.CreateInstance(typeof(TCommandHandler), createReposFunc) as TCommandHandler;
        }
    }

    public class ThereWasNoExceptionButOneWasExpectedException : Exception { }
}