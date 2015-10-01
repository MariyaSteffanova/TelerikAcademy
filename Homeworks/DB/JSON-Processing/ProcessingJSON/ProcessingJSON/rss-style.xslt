<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <style>
       body{
       background-color: #333;
       }
        #title{
        background-color: #509000;
        color: #ffffff;
        height: 50px;
        width:303px;
        font-size: 20px;
        text-align: center;        
        }

      </style>
      <body>
        <h1>Telerik Academy RSS</h1>

        <xsl:for-each select="videos/video">
          <div id="video-container">
            <div id="title">
              <xsl:value-of select="title"/>
            </div>
            <div id="video">
              <xsl:element name="iframe">

                <xsl:attribute name="src">
                  <xsl:value-of select="url"/>
                </xsl:attribute>
              </xsl:element>

            </div>
          </div>
        </xsl:for-each>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
