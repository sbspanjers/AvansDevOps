using AvansDevOps.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Models;

public class Project
{
    private List<Sprint> _sprints;
    private List<BacklogItem> _backlogItems;
    private string _name;
    private IAvansDevOps _devOpsFunctions;
    private IGit _gitFunctions;
    private SprintFactory _sprintFactory;

    public Project(string name, IAvansDevOps avansDevOps, IGit git)
    {
        this._devOpsFunctions = avansDevOps;
        this._gitFunctions = git;
        this._name = name;
        this._backlogItems = new();
        this._sprints = new();
    }
    public void CreateSprint(string name, DateTime startDate, DateTime endDate)
    {
        Sprint sprint = this._sprintFactory.CreateSprint(name, startDate, endDate);
        this._sprints.Add(sprint);
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        this._backlogItems.Add(backlogItem);
    }

    public void SetSprintFactory(SprintFactory sprintFactory)
    {
        this._sprintFactory = sprintFactory;
    }

    public List<BacklogItem> GetBacklogItems()
    {
        //sort on backlog name
        return this._backlogItems.OrderBy(x => x.getName()).ToList();
    }

    public BacklogItem GetBacklogItem(string name)
    {
        return this._backlogItems.FirstOrDefault(x => x.getName() == name);
    }

    public BacklogItem EditBacklogItem(string name, string description, List<SubTask> list)
    {
        var current = this._backlogItems.FirstOrDefault(x => x.getName() == name);
        current.Edit(name, description, list);
        return current;
    }
}
