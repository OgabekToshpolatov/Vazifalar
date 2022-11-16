﻿namespace Classroom.Web.Data;

public class Classroom
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid Key { get; set; } = Guid.NewGuid();

    public virtual ICollection<UserRoom>? Users { get; set; }
    public virtual ICollection<Task>? Tasks { get; set; }
}