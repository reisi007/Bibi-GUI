using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitBisectGUI
{
    class BisectStep
    {
        private Commit commit;
        private int i;
        public Commit getCommit() { return commit; }
        public int getResult() { return i; }
        public bool setResult(int r)
        {
            if (!(r == Result.BAD || r == Result.GOOD || r == Result.SKIP || r == Result.NOTSET))
                return false;
            i = r;
            return true;
        }
        public BisectStep(Commit c, int result)
        {
            commit = c;
            if (-1 <= result && result <= 1)
                i = result;
            else
                i = Result.NOTSET;
        }
        public BisectStep(Commit c)
            : this(c, Result.NOTSET)
        { }
        public override string ToString()
        {
            return (commit == null ? null : commit.Sha);
        }
        public override bool Equals(object obj)
        {
            return (obj != null && obj is BisectStep && commit.Equals(((BisectStep)obj).commit) && i == ((BisectStep)obj).i);
        }
        public override int GetHashCode()
        {
            if (commit == null)
                return base.GetHashCode();
            return commit.GetHashCode();
        }
        public string state()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Commit: ");
            sb.Append(commit.Sha);
            sb.Append(" was ");
            switch (i)
            {
                case (Result.BAD):
                    sb.Append("BAD");
                    break;
                case (Result.GOOD):
                    sb.Append("GOOD");
                    break;
                case (Result.SKIP):
                    sb.Append("SKIPPED");
                    break;
                default:
                    sb.Append("not set yet...");
                    break;
            }
            return sb.ToString();
        }

        public static class Result
        {
            public const int GOOD = 1;
            public const int BAD = -1;
            public const int SKIP = 0;
            public const int NOTSET = int.MinValue;
        }
    }
}
