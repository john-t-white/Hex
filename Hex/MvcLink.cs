using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex
{
	/// <summary>
	/// Represents an HTML achor element in an MVC view.
	/// </summary>
	public class MvcLink
		: IDisposable
	{
		private bool _disposed;
		private readonly ViewContext _viewContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Hex.MvcLink" /> class using the specified view context.
		/// </summary>
		/// <param name="viewContext">An object that encapsulates the information that is required in order to render a view.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="viewContext" /> parameter is null.</exception>
		public MvcLink( ViewContext viewContext )
		{
			if( viewContext == null )
			{
				throw new ArgumentNullException( "viewContext" );
			}

			this._viewContext = viewContext;
		}

		/// <summary>
		/// Releases all resources that are used by the current instance of the <see cref="T:Hex.MvcLink" /> class.
		/// </summary>
		public void Dispose()
		{
			this.Dispose( true );
			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// Releases unmanaged and, optionally, managed resources used by the current instance of the <see cref="T:Hex.MvcLink" /> class.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected virtual void Dispose( bool disposing )
		{
			if( !this._disposed )
			{
				this._disposed = true;
				BeginLinkExtensions.EndLink( this._viewContext );
			}
		}

		/// <summary>
		/// Ends the anchor and disposes of all anchor resources.
		/// </summary>
		public void EndLink()
		{
			this.Dispose( true );
		}
	}
}
