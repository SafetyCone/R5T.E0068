using System;


namespace R5T.E0068
{
    public class TriviaExperiments : ITriviaExperiments
    {
        #region Infrastructure

        public static ITriviaExperiments Instance { get; } = new TriviaExperiments();


        private TriviaExperiments()
        {
        }

        #endregion
    }
}
