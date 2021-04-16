using System;
using System.Collections.Generic;
namespace PkmnApi.Models
{
    public class Pkmn
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Type {get;set;}
        public double Height {get;set;}
        public double Weight {get;set;}
        public string Abilities{get;set;}//List<Abilities>
        public string Moves{get;set;}//List<Moves>
        }
}