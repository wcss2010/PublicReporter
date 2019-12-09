using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace ProjectMilitaryTechnologPlanPlugin.Utility
{
	public class FileOp
	{
		public static Process myProcess;

		public static bool RunWordInstCheck(out string msg)
		{
			msg = "";
			try
			{
				if (FileOp.myProcess != null)
				{
					if (!FileOp.myProcess.HasExited)
					{
						FileOp.myProcess.Kill();
						FileOp.myProcess.WaitForExit();
					}
					FileOp.myProcess = null;
				}
				Process[] processesByName = Process.GetProcessesByName("winword");
				Process[] array = processesByName;
				for (int i = 0; i < array.Length; i++)
				{
					Process process = array[i];
					IntPtr arg_53_0 = process.MainWindowHandle;
					string mainWindowTitle = process.MainWindowTitle;
					if (string.IsNullOrEmpty(mainWindowTitle))
					{
						process.Kill();
					}
				}
			}
			catch (Exception ex)
			{
				msg = ex.ToString();
				return false;
			}
			return true;
		}

		public static bool OpenFile(string path)
		{
			bool result = false;
			FileOp.myProcess = new Process();
			try
			{
				FileOp.myProcess.StartInfo.FileName = path;
				FileOp.myProcess.StartInfo.Verb = "Open";
				FileOp.myProcess.StartInfo.CreateNoWindow = true;
				FileOp.myProcess.Exited += new EventHandler(FileOp.myProcess_Exited);
				FileOp.myProcess.EnableRaisingEvents = true;
				FileOp.myProcess.Start();
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		private static void myProcess_Exited(object sender, EventArgs e)
		{
			FileOp.myProcess = null;
		}

        public static bool CopyDirectory(string SourcePath, string DestinationPath, bool overwriteexisting)
        {
            bool ret = false;
            try
            {
                SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
                DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                        Directory.CreateDirectory(DestinationPath);

                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        flinfo.CopyTo(DestinationPath + flinfo.Name, overwriteexisting);
                    }
                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (CopyDirectory(drs, DestinationPath + drinfo.Name, overwriteexisting) == false)
                            ret = false;
                    }
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }

        public static void WipeFile(string filename, int timesToWrite)
        {
            try
            {
                if (File.Exists(filename))
                {
                    //�����ļ�������Ϊ����������Ϊ�˷�ֹ�ļ��ǽ�����
                    File.SetAttributes(filename, FileAttributes.Normal);
                    //����������Ŀ
                    double sectors = Math.Ceiling(new FileInfo(filename).Length / 512.0);
                    // ����һ����ͬ��С�����⻺��
                    byte[] dummyBuffer = new byte[512];
                    // ����һ�����������Ŀ������
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    // ������ļ���FileStream
                    FileStream inputStream = new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    for (int currentPass = 0; currentPass < timesToWrite; currentPass++)
                    {
                        // �ļ���λ��
                        inputStream.Position = 0;
                        //ѭ��ȫ��������
                        for (int sectorsWritten = 0; sectorsWritten < sectors; sectorsWritten++)
                        {
                            //������������䵽����
                            rng.GetBytes(dummyBuffer);
                            // д���ļ�����
                            inputStream.Write(dummyBuffer, 0, dummyBuffer.Length);
                        }
                    }
                    // ����ļ�
                    inputStream.SetLength(0);
                    // �ر��ļ���
                    inputStream.Close();
                    // ���ԭʼ������Ҫ
                    DateTime dt = new DateTime(2037, 1, 1, 0, 0, 0);
                    File.SetCreationTime(filename, dt);
                    File.SetLastAccessTime(filename, dt);
                    File.SetLastWriteTime(filename, dt);
                    // ɾ���ļ�
                    File.Delete(filename);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}