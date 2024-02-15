using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using static WindowsFormsApp1.Login;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Identity.Core;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public EmployeeModel employee;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (auth())
            {
                MessageBox.Show("Loggin in :)");
                this.Hide();
                var main = new Main();
                main.SetEmployee(employee);
                main.Closed += (s, args) => this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Employee ID or password was not found");
            }
            Console.WriteLine(auth());
        }

        private bool auth()
        {
            employee = new EmployeeModel(txtEmployeeID.Text);
            return employee.getDBEmployee(txtPassword.Text);
        }

        public class AccountController : Controller
        {
            private readonly UserManager<IdentityUser> _userManager;

            public AccountController(UserManager<IdentityUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<IActionResult> Register(string username, string password)
            {
                var user = new IdentityUser { UserName = username };
                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    // User was created successfully.
                }
                else
                {
                    // There was an error creating the user.
                }

                return View();
            }

            private IActionResult View()
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// // Copyright (c) .NET Foundation. All rights reserved.
        /// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
        /// Implements the standard Identity password hashing.
        /// Added another hasher plus error message dialogs for failed attempts.
        /// <typeparam name="TUser">The type used to represent a user.</typeparam>
        public class PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
        {
            /* =======================
             * HASHED PASSWORD FORMATS
             * =======================
             * 
             * Version 2:
             * PBKDF2 with HMAC-SHA1, 128-bit salt, 256-bit subkey, 1000 iterations.
             * (See also: SDL crypto guidelines v5.1, Part III)
             * Format: { 0x00, salt, subkey }
             *
             * Version 3:
             * PBKDF2 with HMAC-SHA256, 128-bit salt, 256-bit subkey, 10000 iterations.
             * Format: { 0x01, prf (UInt32), iter count (UInt32), salt length (UInt32), salt, subkey }
             * (All UInt32s are stored big-endian.)
             */

            private PasswordHasherCompatibilityMode _compatibilityMode;
            private int _iterCount;
            private RandomNumberGenerator _rng;
            private Random random = new Random();


            /// <summary>
            /// Creates a new instance of <see cref="PasswordHasher{TUser}"/>.
            /// </summary>
            /// <param name="optionsAccessor">The options for this instance.</param>
            public PasswordHasher(IOptions<PasswordHasherOptions> optionsAccessor = null)
            {
                var options = optionsAccessor?.Value ?? new PasswordHasherOptions();

                // Generates another random number
                int randomNumber = random.Next(5000, 10000);

                // Sets the IterationCount property to the random number
                options.IterationCount = randomNumber;

                // A new instance of PasswordHasher
                PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

                _compatibilityMode = options.CompatibilityMode;
                switch (_compatibilityMode)
                {
                    case PasswordHasherCompatibilityMode.IdentityV2:
                        // nothing else to do
                        break;

                    case PasswordHasherCompatibilityMode.IdentityV3:
                        _iterCount = options.IterationCount;
                        if (_iterCount < 1)
                        {
                            throw new InvalidOperationException(Resources.InvalidPasswordHasherIterationCount);
                        }
                        break;

                    default:
                        throw new InvalidOperationException(Resources.InvalidPasswordHasherCompatibilityMode);
                }

            }

            // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
            private static bool ByteArraysEqual(byte[] a, byte[] b)
            {
                if (a == null && b == null)
                {
                    return true;
                }
                if (a == null || b == null || a.Length != b.Length)
                {
                    return false;
                }
                var areSame = true;
                for (var i = 0; i < a.Length; i++)
                {
                    areSame &= (a[i] == b[i]);
                }
                return areSame;
            }

            /// <summary>
            /// Returns a hashed representation of the supplied <paramref name="txtPassword"/> for the specified <paramref name="user"/>.
            /// </summary>
            /// <param name="user">The user whose password is to be hashed.</param>
            /// <param name="txtPassword">The password to hash.</param>
            /// <returns>A hashed representation of the supplied <paramref name="txtPassword"/> for the specified <paramref name="user"/>.</returns>
            public virtual string HashPassword(TUser user, string txtPassword)
            {
                if (txtPassword == null)
                {
                    throw new ArgumentNullException(nameof(txtPassword));
                }

                if (_compatibilityMode == PasswordHasherCompatibilityMode.IdentityV2)
                {
                    return Convert.ToBase64String(HashPasswordV2(txtPassword, _rng));
                }
                else
                {
                    return Convert.ToBase64String(HashPasswordV3(txtPassword, _rng));
                }
            }

            private static byte[] HashPasswordV2(string txtPassword, RandomNumberGenerator rng)
            {
                const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
                const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
                const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
                const int SaltSize = 128 / 8; // 128 bits

                // Produce a version 2 (see comment above) text hash.
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);
                byte[] subkey = KeyDerivation.Pbkdf2(txtPassword, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

                var outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
                outputBytes[0] = 0x00; // format marker
                Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
                Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);
                return outputBytes;
            }

            private byte[] HashPasswordV3(string txtPassword, RandomNumberGenerator rng)
            {
                return HashPasswordV3(txtPassword, rng,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterCount: _iterCount,
                    saltSize: 128 / 8,
                    numBytesRequested: 256 / 8);
            }

            private static byte[] HashPasswordV3(string txtPassword, RandomNumberGenerator rng, KeyDerivationPrf prf, int iterCount, int saltSize, int numBytesRequested)
            {
                // Produce a version 3 (see comment above) text hash.
                byte[] salt = new byte[saltSize];
                rng.GetBytes(salt);
                byte[] subkey = KeyDerivation.Pbkdf2(txtPassword, salt, prf, iterCount, numBytesRequested);

                var outputBytes = new byte[13 + salt.Length + subkey.Length];
                outputBytes[0] = 0x01; // format marker
                WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
                WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
                WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
                Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
                Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
                return outputBytes;
            }

            private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
            {
                return ((uint)(buffer[offset + 0]) << 24)
                    | ((uint)(buffer[offset + 1]) << 16)
                    | ((uint)(buffer[offset + 2]) << 8)
                    | ((uint)(buffer[offset + 3]));
            }


            /// <summary>
            /// Returns a <see cref="PasswordVerificationResult"/> indicating the result of a password hash comparison.
            /// </summary>
            /// <param name="user">The user whose password should be verified.</param>
            /// <param name="hashedPassword">The hash value for a user's stored password.</param>
            /// <param name="providedPassword">The password supplied for comparison.</param>
            /// <returns>A <see cref="PasswordVerificationResult"/> indicating the result of a password hash comparison.</returns>
            /// <remarks>Implementations of this method should be time consistent.</remarks>
            public virtual PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
            {
                if (hashedPassword == null)
                {
                    throw new ArgumentNullException(nameof(hashedPassword));
                }
                if (providedPassword == null)
                {
                    throw new ArgumentNullException(nameof(providedPassword));
                }

                byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);

                // read the format marker from the hashed password
                if (decodedHashedPassword.Length == 0)
                {
                    return PasswordVerificationResult.Failed;
                    System.Windows.Forms.MessageBox.Show("Error!", "Verification, Failed!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                }
                switch (decodedHashedPassword[0])
                {
                    case 0x00:
                        if (VerifyHashedPasswordV2(decodedHashedPassword, providedPassword))
                        {
                            // This is an old password hash format - the caller needs to rehash if we're not running in an older compat mode.
                            return (_compatibilityMode == PasswordHasherCompatibilityMode.IdentityV3)
                                ? PasswordVerificationResult.SuccessRehashNeeded
                                : PasswordVerificationResult.Success;
                        }
                        else
                        {
                            return PasswordVerificationResult.Failed;
                            System.Windows.Forms.MessageBox.Show("Error!", "Verification, Failed!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                        }

                    case 0x01:
                        int embeddedIterCount;
                        if (VerifyHashedPasswordV3(decodedHashedPassword, providedPassword, out embeddedIterCount))
                        {
                            // If this hasher was re-configured with a higher iteration count, change the entry now.
                            return (embeddedIterCount < _iterCount)
                                ? PasswordVerificationResult.SuccessRehashNeeded
                                : PasswordVerificationResult.Success;
                        }
                        else
                        {
                            return PasswordVerificationResult.Failed;
                            System.Windows.Forms.MessageBox.Show("Error!", "Verification, Failed!",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                        }

                    default:
                        return PasswordVerificationResult.Failed;
                        System.Windows.Forms.MessageBox.Show("Error!", "Verification, Failed!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                }
            }

            private static bool VerifyHashedPasswordV2(byte[] hashedPassword, string password)
            {
                const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
                const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
                const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
                const int SaltSize = 128 / 8; // 128 bits

                // We know ahead of time the exact length of a valid hashed password payload.
                if (hashedPassword.Length != 1 + SaltSize + Pbkdf2SubkeyLength)
                {
                    return false; // bad size
                    System.Windows.Forms.MessageBox.Show("Error, Invalid Password!", "Please, try again!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                }

                byte[] salt = new byte[SaltSize];
                Buffer.BlockCopy(hashedPassword, 1, salt, 0, salt.Length);

                byte[] expectedSubkey = new byte[Pbkdf2SubkeyLength];
                Buffer.BlockCopy(hashedPassword, 1 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // Hash the incoming password and verify it
                byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);
                return ByteArraysEqual(actualSubkey, expectedSubkey);
            }

            private static bool VerifyHashedPasswordV3(byte[] hashedPassword, string password, out int iterCount)
            {
                iterCount = default(int);

                try
                {
                    // Read header information
                    KeyDerivationPrf prf = (KeyDerivationPrf)ReadNetworkByteOrder(hashedPassword, 1);
                    iterCount = (int)ReadNetworkByteOrder(hashedPassword, 5);
                    int saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);

                    // Read the salt: must be >= 128 bits
                    if (saltLength < 128 / 8)
                    {
                        return false;
                        System.Windows.Forms.MessageBox.Show("Error, Invalid Password!", "Please, try again!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                    }

                    byte[] salt = new byte[saltLength];
                    Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);

                    // Read the subkey (the rest of the payload): must be >= 128 bits
                    int subkeyLength = hashedPassword.Length - 13 - salt.Length;
                    if (subkeyLength < 128 / 8)
                    {
                        return false;
                        System.Windows.Forms.MessageBox.Show("Error, Invalid Password!", "Please, try again!",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    byte[] expectedSubkey = new byte[subkeyLength];
                    Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                    // Hash the incoming password and verify it
                    byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);
                    return ByteArraysEqual(actualSubkey, expectedSubkey);
                }
                catch
                {
                    // This should never occur except in the case of a malformed payload, where
                    // we might go off the end of the array. Regardless, a malformed payload
                    // implies verification failed.
                    return false;
                    System.Windows.Forms.MessageBox.Show("Error, Invalid Password!", "Please, try again!",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                }
            }

            private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
            {
                buffer[offset + 0] = (byte)(value >> 24);
                buffer[offset + 1] = (byte)(value >> 16);
                buffer[offset + 2] = (byte)(value >> 8);
                buffer[offset + 3] = (byte)(value >> 0);
            }
        }
    }

    public interface IActionResult
    {
    }

    public class Controller
    {
    }
}

