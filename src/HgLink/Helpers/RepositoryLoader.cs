namespace GitTools.Git
{
    using Catel.Logging;
    using HgLink;
    using Mercurial;

    public class RepositoryLoader
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public static Repository GetRepo(string gitDirectory)
        {
            var repository = new Repository(gitDirectory);

            var tip = repository.Tip();
            if (tip == null)
            {
                throw Log.ErrorAndCreateException<HgLinkException>("No Tip found. Has repo been initialized?");
            }

            return repository;
        }
    }
}