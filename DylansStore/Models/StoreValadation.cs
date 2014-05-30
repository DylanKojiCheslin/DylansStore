using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DylansStore.Models
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {
    }


    public partial class Category
    {
        public List<Models.Product> Allproducts;
    }

    public class CategoryMetadata
    {
        [Required(ErrorMessage = "You need to enter a category name")
        , MaxLength(100, ErrorMessage = "Name is too long")
        , Display(Name = "Category Name")]
        public string Name;
        

    }

    [MetadataType(typeof(PaymentMetadata))]
    public partial class Payment
    {    }

    public class PaymentMetadata
    {

        [Required
        , DataType(DataType.CreditCard)
        ,StringLength(16, ErrorMessage="Must be 16 numbers in length")]
        public string CCNumer { get; set; }

        [Required
        ,MinLength(3, ErrorMessage="must be at least 3 numbers in length")
        ,MaxLength(4, ErrorMessage="must be 4 numbers or less in length")]
        public int CVC { get; set; }

        [Required
        ,StringLength(2, ErrorMessage = "Use a two letter month format")]
        public string CC_ExpireMonth { get; set; }

        [Required
        ,StringLength(4, ErrorMessage = "Use a four number year format")]
        public string CC_ExpireYear { get; set; }

        [Required
        ,MaxLength(50, ErrorMessage="Card name must be that 50 characters or less")
        ,MinLength(1, ErrorMessage="Card name can't be blank")]
        public string CardName { get; set; }

        [Required
        , MaxLength(50, ErrorMessage = "Card name must be that 50 characters or less")
        , MinLength(1, ErrorMessage = "Card name can't be blank")]
        public string ConfirmationNumber { get; set; }
    }


    [MetadataType(typeof(AddressesMetadata))]
    public partial class Addresses
    {    }

    public class AddressesMetadata
    {

        [Required
        ,MinLength(1, ErrorMessage="Address cant be empty")
        ,MaxLength(100, ErrorMessage="Adress must be 100 characters")]
        public string Address1 { get; set; }

        [MinLength(1, ErrorMessage = "Address cant be empty")
        , MaxLength(100, ErrorMessage = "Adress must be 100 characters or less")]
        public string Address2 { get; set; }
        
        [Required
        ,MinLength(1, ErrorMessage="can't be empty")
        , MaxLength(100, ErrorMessage = "City must be 100 characters or less")]
        public string City { get; set; }


        [Required
        ,StringLength(2, ErrorMessage = "Use a two letter state format")]
        public string State { get; set; }

        [Required
        ,MaxLength(50, ErrorMessage="Postal Code must be that 50 characters or less")
        , MinLength(1, ErrorMessage = "Postal Code can't be blank")]
        public string PostalCode { get; set; }

        [Required
        ,MaxLength(50, ErrorMessage="Type must be 50 characters or less")
        ,MinLength(1, ErrorMessage="Type must not be empty")]
        public string Type { get; set; }
    }
}