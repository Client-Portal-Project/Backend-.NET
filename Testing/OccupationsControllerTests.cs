// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using REST.BusinessLayer;
// using REST.Controllers;
// using REST.DataLayer;
// using REST.Models;
// using Xunit;

// namespace Testing
// {
//     public class OccupationsControllerTests
//     {
//         Mock<IOccupationBL> mockRepo;
//         public OccupationsControllerTests()
//         {
//             mockRepo = new Mock<IOccupationBL>();
//         }

//         [Fact]
//         public void GetOccupationsReturnsOkObjectResult()
//         {
//             mockRepo.Setup(x => x.GetOccupations()).ReturnsAsync(new List<Occupation>());
//             var controller = new OccupationController(mockRepo.Object);

//             var response = controller.GetOccupations();
//             var result = response.Result;

//             Assert.IsType<OkObjectResult>(result);
//         }

//         [Fact]
//         public void FindOccupationByIdReturnsOk()
//         {
//             mockRepo.Setup(x => x.FindOccupationById(It.IsAny<int>())).ReturnsAsync(new Occupation() { Id = 1, Description = "Test Occupation", OccupationName = "Test" });
//             var controller = new OccupationController(mockRepo.Object);

//             var response = controller.FindOccupationById(1);
//             var result = response.Result;

//             Assert.IsType<OkObjectResult>(result);
//         }

//         [Fact]
//         public void FindOccupationByNameReturnsOk()
//         {
//             mockRepo.Setup(x => x.FindOccupationByName(It.IsAny<string>())).ReturnsAsync(new Occupation() { Id = 1, Description = "Test Occupation", OccupationName = "Test" });
//             var controller = new OccupationController(mockRepo.Object);

//             var response = controller.FindOccupationByName("Test");
//             var result = response.Result;

//             Assert.IsType<OkObjectResult>(result);
//         }

//         [Fact]
//         public void AddOccupationReturnsCreated()
//         {
//             Occupation Occupation = new Occupation() { Id = 1, OccupationName = "Test", Description = "Test Occupation" };
//             mockRepo.Setup(x => x.AddOccupation(It.IsAny<Occupation>()));
//             var controller = new OccupationController(mockRepo.Object);

//             var response = controller.CreateOccupation(Occupation);
//             var result = response.Result;

//             Assert.IsType<CreatedResult>(result);
//         }

//     }
// }