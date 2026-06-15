using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Templates
{
    public class ForgotPasswordTemplate
    {

        public  static string GetBody( string resetToken)
        {
            return $@"string body = $@""
<div style='font-family:Arial,sans-serif;
            max-width:600px;
            margin:auto;
            border:1px solid #e0e0e0;
            border-radius:10px;
            overflow:hidden;'>

    <div style='background-color:#ef4444;
                color:white;
                padding:20px;
                text-align:center;'>

        <h1 style='margin:0;'>Fundoo Notes</h1>

        <p style='margin-top:10px;font-size:14px;'>
            Password Reset Request
        </p>

    </div>

    <div style='padding:25px;'>

        <h2>Hello 👋</h2>

        <p>
            We received a request to reset your password.
        </p>

        <p>
            If you made this request, use the reset token below
            to create a new password.
        </p>

        <div style='background:#fff3f3;
                    border:1px solid #fca5a5;
                    padding:20px;
                    border-radius:8px;
                    text-align:center;
                    margin-top:20px;
                    margin-bottom:20px;'>

            <h3 style='margin:0;color:#dc2626;'>
                Reset Token
            </h3>

            <p style='font-size:18px;
                      font-weight:bold;
                      word-break:break-all;'>
                {resetToken}
            </p>

        </div>

        <p>
            For security reasons, do not share this token with anyone.
        </p>

        <p>
            If you did not request a password reset,
            please ignore this email.
        </p>

        <p style='margin-top:25px;'>

            Regards,<br/><br/>

            <strong>Fundoo Notes Team</strong>

        </p>

    </div>

    <div style='background:#f8f8f8;
                text-align:center;
                padding:12px;
                font-size:12px;
                color:#666;'>

        © Fundoo Notes | Secure Password Recovery 🔐

    </div>

</div>";
        }
    }
}
