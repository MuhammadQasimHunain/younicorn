using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Events;
using YounicornApp.Core.Interfaces;
using YounicornApp.Core.Services;

namespace YounicornApp.UnitTests.Core.Entities
{
    public class ItemCompletedEmailNotificationHandlerHandle
    {
        //private ItemCompletedEmailNotificationHandler _handler;
        //private Mock<IEmailSender> _emailSenderMock;

        //public ItemCompletedEmailNotificationHandlerHandle()
        //{
        //    _emailSenderMock = new Mock<IEmailSender>();
        //    _handler = new ItemCompletedEmailNotificationHandler(_emailSenderMock.Object);
        //}

        //[Fact]
        //public async Task ThrowsExceptionGivenNullEventArgument()
        //{
        //    Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null));
        //}

        //[Fact]
        //public async Task SendsEmailGivenEventInstance()
        //{
        //    await _handler.Handle(new ToDoItemCompletedEvent(new ToDoItem()));

        //    _emailSenderMock.Verify(sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        //}
    }
}