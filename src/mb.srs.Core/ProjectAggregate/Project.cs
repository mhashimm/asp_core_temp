﻿using Ardalis.GuardClauses;
using mb.srs.Core.ProjectAggregate.Events;
using mb.srs.SharedKernel;
using mb.srs.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace mb.srs.Core.ProjectAggregate
{
    public class Project : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        private List<ToDoItem> _items = new List<ToDoItem>();
        public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
        public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

        public Project(string name)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
        }

        public void AddItem(ToDoItem newItem)
        {
            Guard.Against.Null(newItem, nameof(newItem));
            _items.Add(newItem);

            var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
            Events.Add(newItemAddedEvent);
        }

        public void UpdateName(string newName)
        {
            Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }
    }
}