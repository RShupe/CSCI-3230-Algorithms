using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace homework1
{
    // Class biorecord
    // Manages the binary records and file access
    class biorecord
    {
        BinaryFile binfile; // Input/output binary file

        // Binary record for plant sampling data
        //    according to C#
        // See http://www.codeproject.com/KB/files/fastbinaryfileinput.aspx
        //   for details
        [StructLayout(LayoutKind.Explicit, Size = 232)]
        private struct bioStruct
        {
            [FieldOffset(0)]
            internal int id;
            [FieldOffset(4)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            internal char[] commonName;
            [FieldOffset(68)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            internal char[] sciName;
            [FieldOffset(132)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            internal char[] latitude;
            [FieldOffset(152)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            internal char[] longitude;
            [FieldOffset(172)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            internal char[] date;
            [FieldOffset(192)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            internal char[] name;
            [FieldOffset(256)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            internal char[] age;

            // Constructor to make sure blanks get in the
            // strings and default values in the other
            // fields
            public bioStruct(int a)
            {
                string blanks = "                                                                                 ";
                id = -1;
                commonName = blanks.ToCharArray(0, 64);
                sciName = blanks.ToCharArray(0, 64);
                latitude = blanks.ToCharArray(0, 20);
                longitude = blanks.ToCharArray(0, 20);
                date = blanks.ToCharArray(0, 20);
                name = blanks.ToCharArray(0, 64);
                age = blanks.ToCharArray(0, 64);
            } // bioStruct()
        } // struct bioStruct()

        // writeRecord translates from normal data to the
        // binary record
        public void writeRecord(int i, string s1, string s2,
                            string lat, string lon, string d, string n, string e)
        {
            // Create a new record and copy the data in, painfully
            bioStruct rec = new bioStruct(1);
            rec.id = i;
            for (int j = 0; j < s1.Length; j++) rec.commonName[j] = s1[j];
            for (int j = 0; j < s2.Length; j++) rec.sciName[j] = s2[j];
            for (int j = 0; j < lat.Length; j++) rec.longitude[j] = lat[j];
            for (int j = 0; j < lon.Length; j++) rec.latitude[j] = lon[j];
            for (int j = 0; j < d.Length; j++) rec.date[j] = d[j];
            for (int j = 0; j < n.Length; j++) rec.name[j] = n[j];
            for (int j = 0; j < e.Length; j++) rec.age[j] = e[j];

            // See the reference above for pinning and
            // marshaling details
            byte[] buffer = new byte[Marshal.SizeOf(typeof(bioStruct))];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(rec, handle.AddrOfPinnedObject(), false);

            // Actually write the data
            binfile.write(buffer, Marshal.SizeOf(typeof(bioStruct)));
            handle.Free();
        } // writeRecord()

        // readRecord handles the details of marshaling data
        // back from the binary file into a record
        private bioStruct readRecord()
        {
            // Create a new record to hold the data read
            bioStruct rec = new bioStruct(1);
            byte[] buffer;

            // Read the data into the byte buffer buffer
            buffer = binfile.read(Marshal.SizeOf(typeof(bioStruct)));
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            // Cast the bytes into the record
            rec = (bioStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),
                 typeof(bioStruct));
            return rec;
        } // readRecord()

        // Opens a | delimited text file, reads its data in
        // normal format, calls writeRecord() to write it in
        // binary form
        public void ProcessTextFile(string textFileName)
        {
            // Create a text file reader
            StreamReader f = new StreamReader(textFileName);

            // Create a binary file writer
            string binFileName = textFileName.Replace(".txt", ".dat");
            System.Console.WriteLine("file name = " + binFileName);
            binfile = new BinaryFile(binFileName, true);

            // Read until done
            while (f.Peek() != -1)
            {
                // Get a line
                string str = f.ReadLine();
                // Split the line by |
                string[] s = str.Split('|');
                // Display the data
                for (int i = 0; i < 8; i++)
                {
                    System.Console.WriteLine(s[i]);

                } // for

                // Write to the binary file
                writeRecord(Convert.ToInt32(s[0]), s[1], s[2],
                    (s[3]),
                    (s[4]), s[5], s[6], s[7]);
            } // while

            // Close the text and binary output files
            f.Close();
            binfile.Close();
        } // ProcessTextFile()

        // ProcessBinaryFile reads records from an existing
        // binary file and displays them
        public void ProcessBinaryFile(string binaryFileName)
        {
            bioStruct rec;  // one record
            long where = 0; // file byte counter
            int i = 0;     // file record counter

            // Open the binary file for read access
            binfile = new BinaryFile(binaryFileName, false);
            // Get its length
            long length = binfile.getLength();

            // Read the first record
            rec = readRecord();
            System.Console.WriteLine("Read from binary file");

            string path = @"C:\Users\ryant\Documents\GitHub\CSCI-3230-Algorithms\Files\";

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "test_2.txt")))
            {
                // Continue while not at end-of-file
                while (where < length)
                {

                    // Convert the record to regular data and
                    // display it
                    System.Console.WriteLine("Record # " + i);
                    System.Console.WriteLine("id: " + rec.id);
                    outputFile.Write(rec.id + "|");
                    string str = new string(rec.commonName);
                    System.Console.WriteLine("common name: " + str);
                    string output = "";
                    for (int z = 0; z < rec.commonName.Length; z++)
                    {
                        if (rec.commonName[z] == ' ' && rec.commonName[z + 1] == ' ')
                        {
                            break;
                        }
                        output += rec.commonName[z];
                    }
                    outputFile.Write(output + "|");
                    output = "";
                    string str2 = new string(rec.sciName);
                    System.Console.WriteLine("scientific name: " + str2);
  
                    for (int z = 0; z < rec.sciName.Length; z++)
                    {
                        if (rec.sciName[z] == ' ' && rec.sciName[z + 1] == ' ')
                        {
                            break;
                        }
                        output += rec.sciName[z];
                    }
                    outputFile.Write(output + "|");
                    output = "";
                    string strlat = new string(rec.latitude);
                    System.Console.WriteLine("latitude: " + strlat);
                    for (int z = 0; z < rec.longitude.Length; z++)
                    {
                        if (rec.longitude[z] == ' ' && rec.longitude[z + 1] == ' ')
                        {
                            break;
                        }
                        output += rec.longitude[z];
                    }
                    outputFile.Write(output + "|");
                    output = "";
                    string strlong = new string(rec.longitude);
                    System.Console.WriteLine("longitude: " + strlong);
                    for (int z = 0; z < rec.latitude.Length; z++)
                    {
                        if (rec.latitude[z] == ' ' && rec.latitude[z + 1] == ' ')
                        {
                            break;
                        }
                        output += rec.latitude[z];
                    }
                    outputFile.Write(output + "|");
                    output = "";
                    string str4 = new string(rec.date);
                    System.Console.WriteLine("date: " + str4);
                    for (int z = 0; z < rec.date.Length; z++)
                    {
                        if (rec.date[z] == ' ' && rec.date[z + 1] == ' ')
                        {
                            break;
                        }
                        output += rec.date[z];
                    }
                    outputFile.Write(output + "|");
                    output = "";
                    string str5 = new string(rec.date);
                    System.Console.WriteLine("name: " + str5);
                    for (int z = 0; z < rec.name.Length; z++)
                    {
                        if (rec.name[z] == ' ' && rec.name[z + 1] == ' ')
                        {
                            break;
                        }
                        output += rec.name[z];
                    }
                    outputFile.Write(output + "|");
                    output = "";
                    string str6 = new string(rec.age);
                    System.Console.WriteLine("age: " + str6);
                    for (int z = 0; z < rec.age.Length; z++)
                    {
                        if(rec.age[z] == ' ' && rec.age[z+1] == ' ')
                        {
                            break;
                        }
                        output += rec.age[z];
                    }
                    outputFile.Write(output + "|");
                    output = "";
                    outputFile.Write("\n");

                    // Read the next record
                    rec = readRecord();

                    // Update the byte and record counters
                    where += Marshal.SizeOf(typeof(bioStruct));
                    i++;
                } // while
            }
            // Close the binary file
            binfile.Close();
        } // ProcessBinaryFile()
        
    } // class biorecord
}
