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

    public Project(string name)
    {
        this._name = name;
        this._backlogItems = new();
        this._sprints = new();
    }
    public void AddSprint(Sprint sprint)
    {
        this._sprints.Add(sprint);
    }
}
