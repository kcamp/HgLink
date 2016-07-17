namespace GitTools.Git
{
    using System.IO;

    public class HgDirFinder
    {
        public static string TreeWalkForDotHgDir(string currentDirectory)
        {
            var gitDirectory = Discover(currentDirectory);

            return gitDirectory?.TrimEnd(Path.DirectorySeparatorChar);
        }

        private static string Discover(string path)
        {
            /*
             * http://www.rubydoc.info/github/libgit2/rugged/Rugged%2FRepository.discover
             * Traverse path upwards until a Git working directory with a .git folder has been found, open it and return it as a Repository object.
             * If path is nil, the current working directory will be used as a starting point.
             * If across_fs is true, the traversal won't stop when reaching a different device than the one that contained path (only applies to UNIX-based OSses).
             */

            var dinfo = new DirectoryInfo(path);
            if (!dinfo.Exists) return null;

            var testPath = Path.Combine(dinfo.FullName, ".hg");
            if (Directory.Exists(testPath)) return path;
            
            if (dinfo.Parent == null) return null;
            return Discover(dinfo.Parent.FullName);
        }
    }
}