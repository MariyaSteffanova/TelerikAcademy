<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">


  <xsl:template match="/">
    <html>
      <style>
        table {
        text-align: center;
        border: 1px solid black;
        }
        
        th{
        background-color: #549000;
        border-bottom: 1px solid black;
        }   
        
        tr:nth-child(even){
        background-color: #808080;
        }
        
        th, td{
        padding: 10px;
        }
        div{
        text-align: right;
        }
      </style>
      <body>
        <h1>Catalogue</h1>
        <table cellspacing="0">
          <tr>
            <th>Name</th>
            <th>Artist</th>
            <th>Year</th>
            <th>Producer</th>
            <th>Price</th>
            <th>Songs</th>
          </tr>
          <xsl:for-each select="catalogue/album">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="year"/>
              </td>
              <td>
                <xsl:value-of select="producer"/>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
              
              <td>
                <xsl:for-each select="songs/song">
                  <div>
                    
                    <span>
                      Title:
                      <xsl:value-of select="title"/> |
                    </span>
                    <span>
                      Duration:
                      <xsl:value-of select="duration"/>
                    </span>
                  </div>
                </xsl:for-each>
              </td>

            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
