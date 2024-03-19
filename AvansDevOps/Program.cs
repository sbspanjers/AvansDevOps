using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Users;

//F01



User stan = new ProductOwner() { Name = "Stan"};
User stijn = new Scrummaster() { Name = "Stijn"};


Pipeline pipeline = new Pipeline();

Project grindSchool = stan.CreateProject("GrindSchool", pipeline, new GitAdapter());

// F03
BacklogItem backlogItem1 = stan.CreateBacklogItem(grindSchool,"Item1", "Create a new website");
BacklogItem backlogItem2 = stan.CreateBacklogItem(grindSchool,"Item2", "Create a new app");

//  F02
//foreach (var item in grindSchool.GetBacklogItems())
//{
//    Console.WriteLine(item.ToString());
//}

// F04
stan.EditBacklogItem(grindSchool, "Item2", "Create a new API", new List<SubTask>() { new SubTask("Create database"), new SubTask("Deploy to Heroku") });
//foreach (var item in grindSchool.GetBacklogItems())
//{
//    Console.WriteLine(item.ToString());
//}

// F06
stan.CreateSprint(grindSchool, "Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), new DeploymentSprintFactory());
//Console.WriteLine(grindSchool.ToString());

// F07
stan.EditSprint(grindSchool, "Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), "sprintertje 1");
//Console.WriteLine(grindSchool.ToString());

// F08
stan.AddBacklogItemToSprint(grindSchool, "Item1", grindSchool.GetSprint("sprintertje 1"));
stan.AddBacklogItemToSprint(grindSchool, "Item2", grindSchool.GetSprint("sprintertje 1"));
//Console.WriteLine(grindSchool.ToString());

// F09
stan.MoveSprintToNextPhase(grindSchool, "sprintertje 1");
stan.MoveSprintToNextPhase(grindSchool, "sprintertje 1");
stan.MoveSprintToNextPhase(grindSchool, "sprintertje 1");
//Expected fase is AfterFinishedState
Console.WriteLine(grindSchool.ToString());






