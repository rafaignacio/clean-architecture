
using System;

namespace com.rafaip.userservice.domains.ValueObjects
{
    public sealed class PasswordVO
    {
        #region Constructor
        private PasswordVO() { }
        #endregion

        #region Attributes
        private string _password;
        #endregion

        #region Properties
        public byte[] Buffer { get; private set; }
        #endregion

        #region Methods
        public static PasswordVO Create(string clear_text)
        {
            if (string.IsNullOrWhiteSpace(clear_text))
            {
                throw new ArgumentNullException("clear_text");
            }

            using (var sha512 = new System.Security.Cryptography.SHA512Managed())
            {
                var buffer = System.Text.UTF8Encoding.UTF8.GetBytes(clear_text);
                var hash = sha512.ComputeHash(buffer);

                return new PasswordVO() { _password = Convert.ToBase64String(hash), Buffer = hash, };
            }
        }

        public static PasswordVO Create(byte[] encoded)
        {
            if (encoded?.Length <= 0)
            {
                throw new ArgumentNullException("encoded");
            }
            return new PasswordVO() { _password = Convert.ToBase64String(encoded), Buffer = encoded };
        }

        public bool Compare(string clear_text)
        {
            return this.Equals((PasswordVO)clear_text);
        }

        public static implicit operator PasswordVO(string clear_text)
        {
            return PasswordVO.Create(clear_text);
        }

        public static implicit operator PasswordVO(byte[] encoded)
        {
            return PasswordVO.Create(encoded);
        }

        public static implicit operator byte[] (PasswordVO password)
        {
            return password.Buffer;
        }

        public override bool Equals(object obj)
        {
            if (obj is PasswordVO o)
            {
                return this._password.Equals(o._password);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this._password.GetHashCode();
        }

        public static bool operator ==(PasswordVO p1, PasswordVO p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(PasswordVO p1, PasswordVO p2)
        {
            return !p1.Equals(p2);
        }

        public override string ToString()
        {
            return _password;
        }
        #endregion
    }
}