﻿using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata {
    public class Finder {
        private readonly List<Person> people;

        public Finder(List<Person> people) {
            this.people = people;
        }

        public Couple Find(Filter filter) {
            if (people.Count < 2) return new Couple();
            var couples = GetPossibleCouples();

            var answer = couples[0];
            switch (filter) {
                case Filter.Closest:
                    return couples.OrderBy(c => c.D).First();

                case Filter.Furthest:
                    return couples.OrderByDescending(c => c.D).First();
            }

            return answer;
        }

        private List<Couple> GetPossibleCouples() {
            var couples = new List<Couple>();

            for (var i = 0; i < people.Count - 1; i++) {
                for (var j = i + 1; j < people.Count; j++) {
                    var couple = new Couple();
                    if (people[i].BirthDate < people[j].BirthDate) {
                        couple.P1 = people[i];
                        couple.P2 = people[j];
                    }
                    else {
                        couple.P1 = people[j];
                        couple.P2 = people[i];
                    }

                    couple.D = couple.P2.BirthDate - couple.P1.BirthDate;
                    couples.Add(couple);
                }
            }

            return couples;
        }
    }
}