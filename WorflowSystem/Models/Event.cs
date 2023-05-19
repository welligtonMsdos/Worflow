using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Worflow.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
}
