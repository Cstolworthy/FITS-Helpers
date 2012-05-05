using System;

namespace UraniaLib
{
	///<summary>
	/// Summary description for UraniaHMS.
	/// </summary>

	public class UraniaHMS
	{
		private long glHours;
		private long glMinutes;
		private double gfSeconds;
		private long glSign;

		public UraniaHMS()
		{
		}

		private void setSign(double pfNum)
		{
			if (pfNum < 0)
			{
				glSign = -1;
			}
			else
			{
				glSign = 1;
			}
		}

		public int IsPositive()
		{
			if (glSign == -1)
			{
				return 0;
			}
			else
			{
				return 1;
			}
		}

		public void setHours(long plHours)
		{
			setSign(plHours);
			glHours = Math.Abs(plHours);
		}

		public void setMinutes(long plMinutes)
		{
			if (glHours == 0)
			{
				setSign(plMinutes);
			}

			glMinutes = Math.Abs(plMinutes);
			while (glMinutes >= 60)
			{
				glMinutes = glMinutes - 60;
				glHours = glHours + 1;
			}
		}

		public void setSeconds(double pfSeconds)
		{
			if ((glHours == 0) && (glMinutes == 0))
			{
				setSign(pfSeconds);
			}
			gfSeconds = Math.Abs(pfSeconds);

			while (gfSeconds >= 60)
			{
				gfSeconds = gfSeconds - 60;
				glMinutes = glMinutes + 1;
			}

			while (glMinutes >= 60)
			{
				glMinutes = glMinutes - 60;
				glHours = glHours + 1;
			}
		}

		public void setHMS(long plHours, long plMinutes, double pfSeconds)
		{
			setSign(plHours);
			glHours = Math.Abs(plHours);
			glMinutes = Math.Abs(plMinutes);
			gfSeconds = Math.Abs(pfSeconds);

			while (gfSeconds >= 60)
			{
				gfSeconds = gfSeconds - 60;
				glMinutes = glMinutes + 1;
			}
			while (glMinutes >= 60)
			{
				glMinutes = glMinutes - 60;
				glHours = glHours + 1;
			}
		}

		public void setDec(double pfDec)
		{
			double fTmp;
			setSign(pfDec);

			glHours = (long)Math.Floor(Math.Abs(pfDec));
			fTmp = (Math.Abs(pfDec) - glHours) * 60;
			glMinutes = (long)Math.Floor(fTmp);
			fTmp = (fTmp - glMinutes) * 60;
			gfSeconds = fTmp;
			while (gfSeconds >= 60)
			{
				gfSeconds = gfSeconds - 60;
				glMinutes = glMinutes + 1;
			}
			while (glMinutes >= 60)
			{
				glMinutes = glMinutes - 60;
				glHours = glHours + 1;
			}
		}

		public long getHours()
		{
			return glHours * glSign;
		}

		public long getMinutes()
		{
			if (glHours == 0)
			{
				return glMinutes * glSign;
			}
			else
			{
				return glMinutes;
			}
		}

		public double getSeconds()
		{
			if ((glHours == 0) && (glMinutes == 0))
			{
				return gfSeconds * glSign;
			}
			else
			{
				return gfSeconds;
			}
		}

		public double getDecFormat()
		{
			double fDec;
			fDec = ((double)glHours + (glMinutes / 60.0) + ((gfSeconds / 60.0 / 60.0))) * (double)glSign;
			return fDec;
		}

		public string getString(string sFormat)
		{
			string sTmp;

			sTmp = glHours.ToString("00") + "h " + glMinutes.ToString("00") + "m " + (gfSeconds.ToString(sFormat)) + "s";

			if (glSign == -1)
			{
				sTmp = "-" + sTmp;
			}
			return sTmp;
		}
	}
}
