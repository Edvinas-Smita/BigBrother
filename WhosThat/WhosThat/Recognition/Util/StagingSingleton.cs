using System.ComponentModel;
using System.Threading;
using Emgu.CV;

namespace WhosThat.Recognition.Util
{
	class StagingSingleton : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate (object sender, PropertyChangedEventArgs args) { };
		public static StagingSingleton Instance = new StagingSingleton();
		private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

		private Mat mat = new Mat();
		public Mat RawCameraMat
		{
			get
			{
				_lock.EnterReadLock();
				try
				{
					return mat;
				}
				finally
				{
					if (_lock.IsReadLockHeld)
						_lock.ExitReadLock();
				}
			}
			set
			{
				_lock.EnterReadLock();
				try
				{
					if (mat != null)
					{
						mat.Dispose();
					}
					mat = value;
					PropertyChanged(this, new PropertyChangedEventArgs("RawCameraMat"));
				}
				finally
				{
					if (_lock.IsReadLockHeld)
						_lock.ExitReadLock();
				}
			}
		}

		private StagingSingleton() { }
	}
}