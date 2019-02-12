//-----------------------------------------------------------------------
// <copyright file="PersonTypeModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace SinglePageApp.Models
{
    /// <summary>
    /// this person type model class
    /// </summary>
    public class PersonTypeModel
    {
        /// <summary>
        /// Gets or sets the actor identifier.
        /// </summary>
        /// <value>
        /// The actor identifier.
        /// </value>
        public int ActorId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the bio.
        /// </summary>
        /// <value>
        /// The bio.
        /// </value>
        public string Bio { get; set; }

    }
}