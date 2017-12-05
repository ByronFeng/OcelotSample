using Moq;
using System;
using Xunit;
using DapperPlus;
using HisAPI.Model.Repository;
using System.Collections.Generic;

namespace HisAPI.XUnitTest
{
    /// <summary>
    /// FeeItemRepository�ִ�����
    /// </summary>
    [Trait("FeeItem�ִ���", "FeeItemRepository")]
    public class FeeItemRepositoryTest
    {
        /// <summary>
        /// ���ݿ�Mock����
        /// </summary>
        Mock<IDapperPlusDB> _dbMock;
        /// <summary>
        /// FeeItem�ִ�����
        /// </summary>
        IFeeItemRepository _feeItemRepository;
        public FeeItemRepositoryTest()
        {
            _dbMock = new Mock<IDapperPlusDB>();
            _feeItemRepository = new FeeItemRepository(_dbMock.Object);
        }

        /// <summary>
        /// ������ģ����ѯ�շ���Ŀ����
        /// </summary>
        [Fact]
        public void GetFeeItem_NullName_Return()
        {
            var list = new List<dynamic>() { new {name="name1" },new { name="name2"} };
            _dbMock.Setup(db => db.Query<dynamic>(It.IsAny<string>(), null, null, false, null, null)).Returns(list);
            var feeItems = _feeItemRepository.GetFeeItem("");
            Assert.Equal(2, feeItems.Count);
        }

        /// <summary>
        /// ������ģ����ѯ�շ���Ŀ����
        /// </summary>
        [Fact]
        public void GetFeeItem_Default_Return()
        {
            var list = new List<dynamic>() { new { name = "name1" }, new { name = "name2" } };
            _dbMock.Setup(db => db.Query<dynamic>(It.IsAny<string>(),  It.IsAny<object>(), null,false, null, null)).Returns(list);
            var feeItems = _feeItemRepository.GetFeeItem("amxl");
            Assert.Equal(2, feeItems.Count);
        }
    }
}
