﻿function get_hostname(o) { var t = o.match(/^http:\/\/[^\/]+/); return t ? t[0] : null } $(document).ready(function () { $(".bookmarkIt").click(function () { var o = $(location).attr("href"), t = get_hostname(o); window.open("https://localhost:44325/bookmarks/New?Site=" + t + "&Link=" + o, "popUpWindow", "height=400, width=650, left=300, top=100, resizable=no, scrollbars=yes, toolbar=no, menubar=no, location=no, directories=no, status=yes") }) });