﻿namespace Nest.Domain.Settings
{
  using System.Collections.Generic;

  public class CustomSimilaritySettings
  {
    public string Name { get; private set; }
    public string Type { get; private set; }
    public Dictionary<string, object> SimilarityParameters { get; private set; }

    public CustomSimilaritySettings(string name, string type)
    {
      Name = name;
      Type = type;
    }

  }
}
