<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Overview
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<div id="map_canvas" style="width: 100%; height: 100%">
    </div>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyD1KmPs4-fHY-R8epgt6P2n02LL2X3M28U&sensor=false">
    </script>
    <script type="text/javascript">
        var trafficOptions = {
            getTileUrl: function (coord, zoom) {
                var center = map.getCenter();

                return "/content/Services/MapHandler.ashx?" + "zoom=" + zoom + "&x=" + coord.x + "&y=" + coord.y + "&lat="+center.Ua+"&lon="+center.Va;
            },
            tileSize: new google.maps.Size(256, 256)
        };

        var trafficMapType = new google.maps.ImageMapType(trafficOptions);

        var map;
        function initialize() {
            map = new google.maps.Map(document.getElementById("map_canvas"));
            map.setCenter(new google.maps.LatLng(37.76, -122.45));
            map.setZoom(12);
            map.setMapTypeId('satellite');
            map.overlayMapTypes.insertAt(0, trafficMapType);
        }
    </script>
    <script type="text/javascript">
        initialize();
    </script>
</asp:Content>
<%--<!DOCTYPE html>--%>
<%--<html>--%>
<%--<head>--%>
<%--    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />--%>
<%--    <style type="text/css">--%>
<%--        html--%>
<%--        {--%>
<%--            height: 100%;--%>
<%--        }--%>
<%--        body--%>
<%--        {--%>
<%--            height: 100%;--%>
<%--            margin: 0;--%>
<%--            padding: 0;--%>
<%--        }--%>
<%--        #map_canvas--%>
<%--        {--%>
<%--            height: 100%;--%>
<%--        }--%>
<%--    </style>--%>
<%--</head>--%>
<%--<body onload="initialize()">--%>
<%--    --%>
<%--</body>--%>
<%--</html>--%>
