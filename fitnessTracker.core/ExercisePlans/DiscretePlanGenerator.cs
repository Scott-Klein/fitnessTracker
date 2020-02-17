using fitnessTracker.core.ExercisePlans;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessTracker.core
{
    public static class DiscretePlanGenerator
    {
        public static DiscreteExercisePlan Generate(DiscreteExercisePlanOptions options)
        {
            var plan = new DiscreteExercisePlan();

            List<ExerciseSet> exerciseSets = GenerateSets(options);

            plan.SetsOfExercise = exerciseSets;
            return plan;
        }

        private static List<ExerciseSet> GenerateSets(DiscreteExercisePlanOptions options)
        {
            List<ExerciseSet> Sets;
            int currentLeadReps, iteration;
            DateTime currentDay;

            SetupSetGeneration(options, out Sets, out currentLeadReps, out currentDay, out iteration);

            while (currentLeadReps < options.MaxReps)
            {
                if (DayOfWorkOut(currentDay, options.Days))
                {
                    for (int i = 0; i < options.Sets; i++)
                    {
                        Sets.Add(CreateSet(currentLeadReps, currentDay, i));
                    }
                }
                LevelUpDifficulty(options, ref currentLeadReps, ref iteration);
                currentDay = currentDay.AddDays(1);
            }

            return Sets;
        }

        private static void SetupSetGeneration(DiscreteExercisePlanOptions options, out List<ExerciseSet> Sets, out int currentLeadReps, out DateTime currentDay, out int iteration)
        {
            Sets = new List<ExerciseSet>();
            currentLeadReps = options.MaxReps / 2;
            currentDay = options.StartDate;
            iteration = 0;
        }

        private static void LevelUpDifficulty(DiscreteExercisePlanOptions options, ref int currentLeadReps, ref int iteration)
        {
            if (iteration++ % options.LevelUpFrequency == 0)
            {
                currentLeadReps += options.LevelUpIntensity;
            }
        }

        public static List<ExerciseSet> CreateSets(int totalReps, int totalSets)
        {
            List<ExerciseSet> exerciseSets = new List<ExerciseSet>();

            GenerateEmptySets(totalSets, exerciseSets);

            exerciseSets = BalanceSetsToProgression(totalReps, exerciseSets);
            return exerciseSets;
        }

        private static List<ExerciseSet> BalanceSetsToProgression(int totalReps, List<ExerciseSet> exerciseSets)
        {
            var weights = WeightGenerator(exerciseSets.Count);
            float weightTotal = GetWeightTotal(weights);
            List<float> cumWeights = GetWeightAccumulative(weights);
            var rand = new Random();
            do
            {
                for (int i = 0; i < totalReps; i++)
                {
                    var threshold = rand.NextDouble() * weightTotal;
                    for (int j = 0; j < cumWeights.Count; j++)
                    {
                        if (threshold < cumWeights[j])
                        {
                            exerciseSets[j].Repetitions += 1;
                            break;
                        }
                    }
                }
            } while (!SetsGetEasier(exerciseSets));


            return exerciseSets;
        }

        public static bool SetsGetEasier(List<ExerciseSet> exerciseSets)
        {
            int reps = int.MaxValue;
            for (int i = 0; i < exerciseSets.Count; i++)
            {
                if (exerciseSets[i].Repetitions > reps)
                {
                    return false;
                }
                reps = exerciseSets[i].Repetitions;
            }
            return true;
        }

        private static List<float> GetWeightAccumulative(List<float> weights)
        {
            List<float> result = new List<float>();
            float accumulation = 0.0f;

            for (int i = 0; i < weights.Count; i++)
            {
                accumulation += weights[i];
                result.Add(accumulation);
            }

            return result;
        }

        private static float GetWeightTotal(List<float> weights)
        {
            float total = 0;
            foreach (var item in weights)
            {
                total += item;
            }
            return total;
        }


        //TODO: Throw an exception if sets < 2
        public static List<float> WeightGenerator(int sets)
        {
            float minWeight = 0.3f;
            float graduation = (1.0f - minWeight) / ((float)sets - 1.0f);

            var weights = new List<float>();
            for (int i = 0; i < sets; i++)
            {
                float weight = 1.0f - (i * graduation);
                weights.Add(weight);
            }

            return weights;

        }

        private static void GenerateEmptySets(int totalSets, List<ExerciseSet> exerciseSets)
        {
            for (int i = 0; i < totalSets; i++)
            {
                ExerciseSet set = new ExerciseSet();
                exerciseSets.Add(set);
            }
        }

        private static void DivideIntoSets(int totalReps, int totalSets, List<ExerciseSet> exerciseSets)
        {
            foreach (var set in exerciseSets)
            {
                set.Repetitions += totalReps / totalSets;
            }
        }

        private static ExerciseSet CreateSet(int currentLeadReps, DateTime currentDay, int i)
        {
            var set = new ExerciseSet();
            set.Day = currentDay;
            set.SetNumber = i + 1;
            set.Repetitions = SetRepetitions(currentLeadReps, i);
            set.RepetitionsCompleted = 0;
            return set;
        }

        private static bool DayOfWorkOut(DateTime currentDay, ExerciseDays days)
        {
            switch (currentDay.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    if (days.Sunday)
                        return true;
                    break;
                case DayOfWeek.Monday:
                    if (days.Monday)
                        return true;
                    break;
                case DayOfWeek.Tuesday:
                    if (days.Tuesday)
                        return true;
                    break;
                case DayOfWeek.Wednesday:
                    if (days.Wednesday)
                        return true;
                    break;
                case DayOfWeek.Thursday:
                    if (days.Thursday)
                        return true;
                    break;
                case DayOfWeek.Friday:
                    if (days.Friday)
                        return true;
                    break;
                case DayOfWeek.Saturday:
                    if (days.Saturday)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

        private static int SetRepetitions(int leadReps, int setNumber)
        {
            int minReps = leadReps / 10;

            if (true)
            {

            }
            int result = leadReps - (setNumber * minReps);


            if (result > minReps)
            {
                return result;
            } else
            {
                return minReps;
            }
        }
    }
}
