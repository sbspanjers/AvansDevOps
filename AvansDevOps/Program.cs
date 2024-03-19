

using AvansDevOps.Domain.Adapter.DevOpsAdapter;
using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

// Factory for creating the sprints
SprintFactory DeploymentSprintFactory = new DeploymentSprintFactory();
SprintFactory ReviewSprintFactory = new ReviewSprintFactory();



// Technologies
IAvansDevOps avansDevOps = new DevOpsAdapter();
IGit git = new GitAdapter();

// F01: Als gebruiker wil ik een project aan kunnen maken
Project picoParkProject = new("Picopark project", avansDevOps, git);
//Dev pipeline??
//Codebase??

picoParkProject.SetSprintFactory(DeploymentSprintFactory);
picoParkProject.CreateSprint("Deployment Sprint 1", DateTime.Now, DateTime.Now.AddDays(14));

// F03: Als gebruiker wil ik een backlog item aan kunnen maken
picoParkProject.AddBacklogItem(new BacklogItem("US1", "Een gebruiker wil poppetjes kunnen maken", picoParkProject));
//ADD USERS

// F02: Als gebruiker wil ik requirements bij kunnen houden in een product backlog
List<BacklogItem> requirements = picoParkProject.GetBacklogItems();
BacklogItem requirement1 = picoParkProject.GetBacklogItem("US1");

// F04: Als gebruiker wil ik een backlog item aan kunnen passen
picoParkProject.EditBacklogItem("US1", "Een gebruiker wil poppetjes kunnen maken", new List<SubTask> { new SubTask("doe iets") });


