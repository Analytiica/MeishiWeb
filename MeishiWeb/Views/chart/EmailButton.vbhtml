﻿
@ModelType MeishiWeb.MeishiWeb.Models.EmailButtonViewModel

<table width = "100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td bgcolor = "#ffffff" align="center" style="padding: 20px 30px 60px 30px;">
<table border = "0" cellspacing="0" cellpadding="0">
    <tr>
        <td align = "center" style="border-radius: 3px;" bgcolor="#539be2">
            <a href = "@Model.Url" target="_blank" style="font-size: 20px; font-family: Helvetica, Arial, sans-serif; color: #ffffff; text-decoration: none; color: #ffffff; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid #539be2; display: inline-block;">
@Model.Text
                        </a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>