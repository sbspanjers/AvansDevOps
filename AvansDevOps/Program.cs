using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Observer.Subscribers;
using AvansDevOps.Domain.Users;

//F01



User stan = new ProductOwner() { Name = "Stan"};


Pipeline pipeline = new Pipeline() { Name="release pipeline"};
// F13 Pipeline instellen
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
//stan.ConnectDeploymentSprintToPipelineOfProject(grindSchool, "sprintertje 1");
//Console.WriteLine(grindSchool.ToString());

// F08
stan.AddBacklogItemToSprint(grindSchool, "Item1", grindSchool.GetSprint("sprintertje 1"));
stan.AddBacklogItemToSprint(grindSchool, "Item2", grindSchool.GetSprint("sprintertje 1"));
//Console.WriteLine(grindSchool.ToString());

// F09
grindSchool.GetSprint("sprintertje 1").AddSubscriber(new WhatsappSubscriber());
//stan.MoveSprintToNextPhase(grindSchool, "sprintertje 1");// CreatedState -> StartedState
//stan.MoveSprintToNextPhase(grindSchool, "sprintertje 1"); // StartedState -> FinishedState
//stan.MoveSprintToNextPhase(grindSchool, "sprintertje 1"); // FinishedState -> AfterFinishedState -> CancelledState

//Expected fase is AfterFinishedState
//Console.WriteLine(grindSchool.ToString());

// F10
//Console.WriteLine(stan.SeeCurrentSprintState(grindSchool, "sprintertje 1"));

// F11
//stan.MoveSprintToNextPhase(grindSchool, "sprintertje 1"); // AfterFinishedState -> ClosedState (deploy successful) || AfterFinishedState -> CancelledState (deploy failed)
//Console.WriteLine(grindSchool.ToString());

// F12
//Console.WriteLine(grindSchool.ToString());

// F14
//stan.CancelOrBackToFinishPipeline(grindSchool, "sprintertje 1", true);
//Console.WriteLine(grindSchool.ToString()); // Closed || Error

// F15

Pipeline testPipeline = new Pipeline() { Name= "test pipeline"};
stan.ConnectPipelineToSprint(grindSchool, "sprintertje 1", testPipeline);
//Console.WriteLine(grindSchool.GetSprint("sprintertje 1").ToString());


// F16
stan.CreateSprint(grindSchool, "ReviewSprint", DateTime.Now, DateTime.Now.AddDays(14), new ReviewSprintFactory());
stan.AddBacklogItemToSprint(grindSchool, "Item1", grindSchool.GetSprint("ReviewSprint"));
stan.AddBacklogItemToSprint(grindSchool, "Item2", grindSchool.GetSprint("ReviewSprint"));



stan.MoveSprintToNextPhase(grindSchool, "ReviewSprint"); //CreatedState -> StartedState
stan.MoveSprintToNextPhase(grindSchool, "ReviewSprint"); //StartedState -> FinishedState
stan.CreateReview(grindSchool, "ReviewSprint", "Dit is een review");

// F17
User stijn = new Scrummaster() { Name = "Stijn" };
stan.UploadDocumentToFinishReviewSpint(grindSchool, "ReviewSprint", "Dit is een document", "Dit is de content van het document");

// F18

//Console.WriteLine(grindSchool.GetSprint("ReviewSprint").ToString());

//Forum forum = new Forum();
//var thread = stan.CreateReviewThread(grindSchool, "Item1", "Review thread", forum);
//stan.AddCommentToReviewThread(thread, "Dit is een noob feature");

//Console.WriteLine(forum.ToString());
