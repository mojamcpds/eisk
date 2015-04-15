using System;
using System.Collections;
using System.Collections.Generic;

namespace Utilities
{
    /// <summary>
    /// This is the helper collection class, that holds generic type data.
    /// This type will be used to manipulate generic class.
    /// Class architecture designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
    /// </summary>
    /// <typeparam name="GenericType"></typeparam>
    public class CustomCollection<TGenericType> : CollectionBase, IList<TGenericType>
    {
        /// <summary>
        /// Adds an object to the collection.
        /// </summary>
        /// <param name="GenericObject">Generic object that is to be added</param>
        public void Add(TGenericType item)
        {
            InnerList.Add(item);
        }

        /// <summary>
        /// Removes an object from the collection.
        /// </summary>
        /// <param name="index">position of the item to be removed</param>
        public void Remove(int index)
        {
            InnerList.RemoveAt(index);
        }

        /// <summary>
        /// Gets and sets the appropriate object in the specified index.
        /// </summary>
        /// <param name="index">position of the object</param>
        /// <returns>Generic Object</returns>
        public TGenericType this[int index]
        {
            get { return ((TGenericType)List[index]); }
            set { List[index] = value; }
        }


        #region IList<TGenericType> Members

        /// <summary>
        /// Gets the position of the specified generic object in the list.
        /// </summary>
        /// <param name="item">Generic Object</param>
        /// <returns>position</returns>
        public int IndexOf(TGenericType item)
        {
            return this.InnerList.IndexOf(item);
        }

        /// <summary>
        /// Inserts specified generic object in the list in a specified position.
        /// </summary>
        /// <param name="item">Generic Object</param>
        public void Insert(int index, TGenericType item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICollection<GenericType> Members

        /// <summary>
        /// Check generic object is exists or not
        /// </summary>
        /// <param name="item">Generic Object</param>
        /// <returns>success/unsuccess</returns>
        public bool Contains(TGenericType item)
        {
            return this.InnerList.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array">Generic Object array</param>
        /// <param name="arrayIndex">targeted arry index</param>
        public void CopyTo(TGenericType[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Check the read only property
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.InnerList.IsReadOnly; }
        }
        /// <summary>
        /// Remove the generic object
        /// </summary>
        /// <param name="item">Generic Object</param>
        /// <returns>success/unsuccess</returns>
        public bool Remove(TGenericType item)
        {
            try
            {
                this.InnerList.Remove(item);
                return true;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region IEnumerable<GenericType> Members

        /// <summary>
        /// Get the Enumerator
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<TGenericType> GetEnumerator()
        {
            return (IEnumerator < TGenericType > )this.InnerList.GetEnumerator(); 
        }

        #endregion

    }//end of GenericCollection<GenericType>

}