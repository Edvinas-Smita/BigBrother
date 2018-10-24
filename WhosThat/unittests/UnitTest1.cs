using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhosThat;
using WhosThat.Recognition;
using WhosThat.UserManagement.Util;
using System.Drawing;
using System.Windows.Forms;

namespace unittests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIdFactory()
        {
            int initial_value = 4;
            int expected = 5;
            IdFactory.SetCurrentId(initial_value);

            int actual = IdFactory.GetCurrentId();
            Assert.AreEqual(expected, actual);	//should get the next id

	        int nextId = IdFactory.GetCurrentId();
			Assert.AreNotEqual(expected, nextId);	//should not be the same as last gotten id
        }

        [TestMethod]
        public void FindPersonByIDTest()
        {
            Person personTest = new Person("name", "nice", "nice");
            int personId = personTest.Id;
	        Person personExpected = personTest;
            Storage.People.Add(personTest);

            Person personActual = Storage.FindPersonByID(personId);
            Assert.AreEqual(personExpected, personActual);	//should find exactly the original person since we have its id

	        Person personFromRandomId = Storage.FindPersonByID(1337);
			Assert.AreNotEqual(personExpected, personFromRandomId);	//should not find any person
        }

	    [TestMethod]
	    public void ResizeTest()
	    {
			var original = new Size(640, 480);
		    var newWidth = 320;
			var expected = new Size(320, 240);
		    var actual = UtilStatic.ResizeByWidthMaintainAspectRatio(original, newWidth);
			Assert.AreEqual(expected, actual);	//height and width should have halved since newWidth is half the original

			original = new Size(0, 1337);
		    newWidth = 420;
			expected = new Size(0, 1337);
		    actual = UtilStatic.ResizeByWidthMaintainAspectRatio(original, newWidth);
		    Assert.AreEqual(expected, actual);	//should not have resized it because of zero width
		}

	    [TestMethod]
	    public void NoHScrollBarWidthTest()
	    {
			var panel = new FlowLayoutPanel();
			panel.Size = new Size(500, 500);
		    panel.WrapContents = true;
		    panel.AutoScroll = true;
		    var width = UtilStatic.PanelWidthForNoHScrollBar(panel);
			var wideLabel = UtilStatic.HSeperatorFactory(width);

			panel.Controls.Add(wideLabel);
			Assert.AreEqual(false, panel.HorizontalScroll.Visible);	//should not be visible since everything is setup

			panel.Size = new Size(50, 50);
			Assert.AreEqual(true, panel.HorizontalScroll.Visible);	//should be visible since content width hasn't changed but panels width has

		    wideLabel.Width = UtilStatic.PanelWidthForNoHScrollBar(panel);
		    Assert.AreEqual(false, panel.HorizontalScroll.Visible);	//should not be visible since content has been resized to not show bar
		}
    }
}
