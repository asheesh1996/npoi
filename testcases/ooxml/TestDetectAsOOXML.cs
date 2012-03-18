
/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for Additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */


namespace TestCases.OOXML
{

    using NPOI.OpenXml4Net.OPC;
    using System.IO;
    using NPOI.Util;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NPOI;
    using NPOI.HSSF;
    using TestCases.HSSF;

    /**
     * Class to test that HXF correctly detects OOXML
     *  documents
     */
    [TestClass]
    public class TestDetectAsOOXML
    {
        [TestMethod]
        public void TestOpensProperly()
        {
            OPCPackage.Open(HSSFTestDataSamples.OpenSampleFileStream("sample.xlsx"));
        }
        [TestMethod]
        public void TestDetectAsPOIFS()
        {
            Stream in1;

            // ooxml file is
            in1 = new PushbackStream(
                    HSSFTestDataSamples.OpenSampleFileStream("SampleSS.xlsx")
            );
            Assert.IsTrue(POIXMLDocument.HasOOXMLHeader(in1));

            // xls file isn't
            in1 = new PushbackStream(
                    HSSFTestDataSamples.OpenSampleFileStream("SampleSS.xls")
            );
            Assert.IsFalse(POIXMLDocument.HasOOXMLHeader(in1));

            // text file isn't
            in1 = new PushbackStream(
                    HSSFTestDataSamples.OpenSampleFileStream("SampleSS.txt")
            );
            Assert.IsFalse(POIXMLDocument.HasOOXMLHeader(in1));
        }
    }
}


