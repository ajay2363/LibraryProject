using System;
using System.Collections.Generic;
using System.Text;
using LibraryData.Models;

namespace LibraryData
{
    public interface ILibraryAsset
    {
        IEnumerable<LibraryAsset> GetAll();
        LibraryAsset GetByID(int id);
        void Add(LibraryAsset newAsset);
        string getAuthororDirector(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);
        LibraryBranch GetCurrentLocation(int id);


    }
}
