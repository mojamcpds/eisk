namespace HelperUtilities
{
    using System;
    using System.Collections.ObjectModel;
    /// <summary>
	/// This a searching utility, through which we can store data in key-value pair, 
	/// and value of a key can be found through indexing the key value
	/// Included By: Mohammad Ashraful Alam [ ashraf@mvps.org ] 24-08-2005
	/// Credits: MSDN
	/// </summary>
	public class ShortStringCollection : KeyedCollection<String,String>  
	{
		/// <summary>
		/// Gets the value string for this indexed key
		/// </summary>
		

        protected override string GetKeyForItem(string item)
        {
            return item;
        }
    }
}
/*      ---------------------------------------
 *      Old Code
 * ---------------------------------------------
   
        public String this[ String key ]  
		{
			get  
			{
				return( (String) Dictionary[key] );
			}
			set  
			{
				Dictionary[key] = value;
			}
		}
 
		/// <summary>
		/// When implemented by a class, gets an <see cref="T:System.Collections.ICollection"/> containing the keys of the <see cref="T:System.Collections.IDictionary"/>.
		/// </summary>
		/// <value></value>
		public ICollection Keys  
		{
			get  
			{
				return( Dictionary.Keys );
			}
		}

		/// <summary>
		/// Gets the collection of values
		/// </summary>
		/// <value></value>
		public ICollection Values  
		{
			get  
			{
				return( Dictionary.Values );
			}
		}

		/// <summary>
		/// Adds a key and value into the dictionary
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Add( String key, String value )  
		{
			Dictionary.Add( key, value );
		}

		/// <summary>
		/// Determines whether [contains] [the specified key].
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// 	<c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.
		/// </returns>
		public bool Contains( String key )  
		{
			return( Dictionary.Contains( key ) );
		}

		/// <summary>
		/// Removes the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		public void Remove( String key )  
		{
			Dictionary.Remove( key );
		}

		/// <summary>
		/// Performs additional custom processes before inserting a new element into the
		/// <see cref="T:System.Collections.DictionaryBase"/> instance.
		/// </summary>
		/// <param name="key">The key of the element to insert.</param>
		/// <param name="value">The value of the element to insert.</param>
		protected override void OnInsert( Object key, Object value )  
		{
			if ( key.GetType() != Type.GetType("System.String") )
				throw new ArgumentException( "key must be of type String.", "key" );
			else  
			{
//				String strKey = (String) key;
//				if ( strKey.Length > 5 )
//					throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
			}

			if ( value.GetType() != Type.GetType("System.String") )
				throw new ArgumentException( "value must be of type String.", "value" );
			else  
			{
//				String strValue = (String) value;
//				if ( strValue.Length > 5 )
//					throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
			}
		}

		/// <summary>
		/// Performs additional custom processes before removing an element from the <see cref="T:System.Collections.DictionaryBase"/> instance.
		/// </summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <param name="value">The value of the element to remove.</param>
		protected override void OnRemove( Object key, Object value )  
		{
			if ( key.GetType() != Type.GetType("System.String") )
				throw new ArgumentException( "key must be of type String.", "key" );
			else  
			{
//				String strKey = (String) key;
//				if ( strKey.Length > 5 )
//					throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
			}
		}

		/// <summary>
		/// Performs additional custom processes before setting a value in the <see cref="T:System.Collections.DictionaryBase"/> instance.
		/// </summary>
		/// <param name="key">The key of the element to locate.</param>
		/// <param name="oldValue">The old value of the element associated with <paramref name="key"/>.</param>
		/// <param name="newValue">The new value of the element associated with <paramref name="key"/>.</param>
		protected override void OnSet( Object key, Object oldValue, Object newValue )  
		{
			if ( key.GetType() != Type.GetType("System.String") )
				throw new ArgumentException( "key must be of type String.", "key" );
			else  
			{
//				String strKey = (String) key;
//				if ( strKey.Length > 5 )
//					throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
			}

			if ( newValue.GetType() != Type.GetType("System.String") )
				throw new ArgumentException( "newValue must be of type String.", "newValue" );
			else  
			{
//				String strValue = (String) newValue;
//				if ( strValue.Length > 5 )
//					throw new ArgumentException( "newValue must be no more than 5 characters in length.", "newValue" );
			}
		}

		/// <summary>
		/// Performs additional custom processes when validating the element with the specified key and value.
		/// </summary>
		/// <param name="key">The key of the element to validate.</param>
		/// <param name="value">The value of the element to validate.</param>
		protected override void OnValidate( Object key, Object value )  
		{
			if ( key.GetType() != Type.GetType("System.String") )
				throw new ArgumentException( "key must be of type String.", "key" );
			else  
			{
//				String strKey = (String) key;
//				if ( strKey.Length > 5 )
//					throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
			}

			if ( value.GetType() != Type.GetType("System.String") )
				throw new ArgumentException( "value must be of type String.", "value" );
			else  
			{
//				String strValue = (String) value;
//				if ( strValue.Length > 5 )
//					throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
			}//end of if-else
		}//end of function

	}//end of ShortStringDictionary class


//	public class SamplesDictionaryBase  
//	{
//
//		public static void Main()  
//		{
// 
//			// Creates and initializes a new DictionaryBase.
//			ShortStringDictionary mySSC = new ShortStringDictionary();
//
//			// Adds elements to the collection.
//			mySSC.Add( "One", "a" );
//			mySSC.Add( "Two", "ab" );
//			mySSC.Add( "Three", "abc" );
//			mySSC.Add( "Four", "abcd" );
//			mySSC.Add( "Five", "abcde" );
//
//			// Tries to add a value that is too long.
//			try  
//			{
//				mySSC.Add( "Ten", "abcdefghij" );
//			}
//			catch ( ArgumentException e )  
//			{
//				Console.WriteLine( e.ToString() );
//			}
//
//			// Tries to add a key that is too long.
//			try  
//			{
//				mySSC.Add( "Eleven", "ijk" );
//			}
//			catch ( ArgumentException e )  
//			{
//				Console.WriteLine( e.ToString() );
//			}
//
//			Console.WriteLine();
//
//			// Displays the contents of the collection using the enumerator.
//			Console.WriteLine( "Initial contents of the collection:" );
//			PrintKeysAndValues( mySSC );
//
//			// Searches the collection with Contains.
//			Console.WriteLine( "Contains \"Three\": {0}", mySSC.Contains( "Three" ) );
//			Console.WriteLine( "Contains \"Twelve\": {0}", mySSC.Contains( "Twelve" ) );
//			Console.WriteLine();
//
//			// Removes an element from the collection.
//			mySSC.Remove( "Two" );
//
//			// Displays the contents of the collection using the Keys property.
//			Console.WriteLine( "New state of the collection:" );
//			PrintKeysAndValues3( mySSC );
//
//		}
//
//		// Uses the enumerator. 
//		public static void PrintKeysAndValues( ShortStringDictionary myCol )  
//		{
//			DictionaryEntry myDE;
//			System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
//			while ( myEnumerator.MoveNext() )
//				if ( myEnumerator.Current != null )  
//				{
//					myDE = (DictionaryEntry) myEnumerator.Current;
//					Console.WriteLine( "   {0,-5} : {1}", myDE.Key, myDE.Value );
//				}
//			Console.WriteLine();
//		}
//
//		// Uses the foreach statement which hides the complexity of the enumerator.
//		public static void PrintKeysAndValues2( ShortStringDictionary myCol )  
//		{
//			foreach ( DictionaryEntry myDE in myCol )
//				Console.WriteLine( "   {0,-5} : {1}", myDE.Key, myDE.Value );
//			Console.WriteLine();
//		}
//
//		// Uses the Keys property and the Item property.
//		public static void PrintKeysAndValues3( ShortStringDictionary myCol )  
//		{
//			ICollection myKeys = myCol.Keys;
//			foreach ( String k in myKeys )
//				Console.WriteLine( "   {0,-5} : {1}", k, myCol[k] );
//			Console.WriteLine();
//		}//end of function
//
//	}//end of class 
}//end of namespace

/* 
This code produces the following output.

System.ArgumentException: value must be no more than 5 characters in length.
Parameter name: value
   at ShortStringDictionary.OnValidate(Object key, Object value)
   at System.Collections.DictionaryBase.System.Collections.IDictionary.Add(Object key, Object value)
   at SamplesDictionaryBase.Main()
System.ArgumentException: key must be no more than 5 characters in length.
Parameter name: key
   at ShortStringDictionary.OnValidate(Object key, Object value)
   at System.Collections.DictionaryBase.System.Collections.IDictionary.Add(Object key, Object value)
   at SamplesDictionaryBase.Main()

Initial contents of the collection:
   One   : a
   Four  : abcd
   Three : abc
   Two   : ab
   Five  : abcde

Contains "Three": True
Contains "Twelve": False

New state of the collection:
   One   : a
   Four  : abcd
   Three : abc
   Five  : abcde

*/
