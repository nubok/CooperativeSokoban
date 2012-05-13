using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CooperativeSokoban
{
    enum LevelLoadingResult
    {
        OK, 
        FileNotFound, 
        InvalidLevel
    }

    enum LevelFileType
    {
        XsbFile,
        HsbFile,
        TxtFile
    }
    
    class LevelLoader
    {
        public static LevelLoadingResult loadLevel(string filename)
        {
            FileStream fsInput;

            if (filename.Length <= 4)
                return LevelLoadingResult.InvalidLevel;

            LevelFileType fileType;
            
            {
                string ending = filename.Substring(filename.Length - 3).ToLower();
                LevelFileType? ntype = 
                    (ending == "xsb") ? LevelFileType.XsbFile :
                    (ending == "hsb") ? LevelFileType.HsbFile :
                    (ending == "txt") ? LevelFileType.TxtFile : new Nullable<LevelFileType>();

                if (ntype == null)
                    return LevelLoadingResult.InvalidLevel;

                fileType = (LevelFileType) ntype;
            }

            try
            {
                fsInput = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                return LevelLoadingResult.FileNotFound;
            }
            StreamReader srInput = new StreamReader(fsInput);

            LinkedList<LinkedList<string>> levels = new LinkedList<LinkedList<string>>();
            LinkedList<string> currentLevel = (fileType == LevelFileType.TxtFile) ? 
                null : new LinkedList<string>();

            {
                string szSrcLine;
                while ((szSrcLine = srInput.ReadLine()) != null)
                {
                    if (szSrcLine.StartsWith(";"))
                    {
                        if (!szSrcLine.EndsWith(".xsb")) // TODO ".hsb"
                        {
                            return LevelLoadingResult.InvalidLevel;
                        }

                        // The current level is done
                        levels.AddLast(currentLevel);
                        currentLevel = new LinkedList<string>();
                    }

                    //lines.AddLast(szSrcLine);
                }
            }

            //try
            //{
            //    int maxlen = currentLevel.Max(str => str.Length);
            //}
            //// Happens when list is empty
            //catch (InvalidOperationException)
            //{
            //}

            srInput.Close();
            fsInput.Close();

            return LevelLoadingResult.OK;
        }
    }
}
