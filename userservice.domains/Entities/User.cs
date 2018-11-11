
using System;
using com.rafaip.userservice.domains.ValueObjects;

namespace com.rafaip.userservice.domains.Entities
{
    public class User
    {
        #region Constructor
        private User() { }
        #endregion

        #region Properties
        private PasswordVO Password { get; set; }
        public Guid ID { get; private set; } = Guid.NewGuid();
        public EmailVO Email { get; private set; }
        public string Name { get; private set; }
        #endregion

        #region Methods
        public static User Create(EmailVO email, string name, PasswordVO password, string id = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            var output = new User()
            {
                Email = email,
                Name = name,
                Password = password,
            };

            if (!string.IsNullOrWhiteSpace(id))
            {
                if (Guid.TryParse(id, out Guid guid))
                {
                    output.ID = guid;
                }
                else
                {
                    throw new ArgumentException("ID inválido", "id");
                }
            }

            return output;
        }

        public bool CheckPassword(string clear_text)
        {
            return this.Password.Compare(clear_text);
        }
        #endregion
    }
}