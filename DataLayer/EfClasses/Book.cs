// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace DataLayer.EfClasses
{
    public class Book                                   //#A
    {
        public int BookId { get; set; } //#B
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Holds the url to get the image of the book
        /// </summary>
        public string ImageUrl { get; set; }
        public bool SoftDeleted { get; set; }

        //-----------------------------------------------

        //relationships

        //You can load data in three ways: eager loading, explicit loading, select loading, and lazy loading

        //Be aware that EF Core won’t load any relationships in an entity class unless you ask it to. If you load a Book class, each of the relationship properties in the Book entity class (Promotion, Reviews, and AuthorsLink) will be null by default.
        //This default behavior of NOT loading relationships is correct, because it means that EF Core minimizes the database accesses. If you want to load a relationship, you need to add code to tell EF Core to do that.

        public PriceOffer Promotion { get; set; }        //#C
        public ICollection<Review> Reviews { get; set; } //#D
        public ICollection<BookAuthor> AuthorsLink { get; set; } //#E
    }
    /****************************************************#
    #A The Book class contains the main book information
    #B I use EF Core's 'by convention' approach to defining the primary key of this entity class. In this case I use <ClassName>Id, and because the property if of type int EF Core assumes that the database will use the SQL IDENTITY command to create a unique key when a new row is added.
    #C This is the link to the optional PriceOffer
    #D There can be zero to many Reviews of the book. because the Reviews property is of the .NET type ICollection<Review>, the relationship is a one-to-many relationship. 
    #E This provides a link to the Many-to-Many linking table that links to the Authors of this book
     * **************************************************/
}