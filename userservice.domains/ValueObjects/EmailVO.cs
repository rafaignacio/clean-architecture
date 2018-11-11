using System;
using System.Text.RegularExpressions;

namespace com.rafaip.userservice.domains.ValueObjects
{
    public sealed class EmailVO
    {
        #region Constructor
        private EmailVO() { }
        static EmailVO()
        {
            _regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }
        #endregion

        #region Attributes
        private string _email = string.Empty;
        private static readonly Regex _regex;
        #endregion

        #region Methods
        public static EmailVO Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("email");
            }

            if (_regex.Match(email).Success)
            {
                return new EmailVO() { _email = email };
            }
            else
            {
                throw new ArgumentException("e-mail inválido", "email");
            }
        }

        public static implicit operator string(EmailVO email)
        {
            return email._email;
        }

        public static implicit operator EmailVO(string email)
        {
            return EmailVO.Create(email);
        }

        public override string ToString()
        {
            return _email;
        }
        #endregion
    }
}