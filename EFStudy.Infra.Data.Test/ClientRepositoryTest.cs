using System.Linq;
using EFStudy.Core.Entities;
using EFStudy.Infra.Data.Interfaces;
using EFStudy.Infra.Data.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace EFStudy.Infra.Data.Test
{
    [TestFixture]
    public class ClientRepositoryTest
    {
        private MyContext _context;
        private IUnitOfWork _uow;
        private IClientRepository _sut;

        [SetUp]
        public void Setup()
        {
            _context = new MyContext("PlaygroundEFTest");
            _uow = new UnitOfWork(_context);
            _sut = new ClientRepository(_uow);
        }

        [Test]
        public void PossoInserirClient()
        {
            var client = new Client
            {
                Name = "Client Test"
            };

            _sut.Create(client);
            _uow.Commit();

            var clientCreated = _sut.GetAll().FirstOrDefault();

            clientCreated.Id.Should().Be(client.Id);
        }

        [TearDown]
        public void TearDown()
        {
            if (_uow.Transaction != null)
                _uow.Rollback();
            _uow.Dispose();
        }
    }
}
