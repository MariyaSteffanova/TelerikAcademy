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
        <h1>Telerik Academy Students</h1>
        <table cellspacing="0">
          <tr>
            <th>Student</th>
            <th>Sex</th>
            <th>Birth Date</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty Number</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="students/student">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birthDate"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="facultyNumber"/>
              </td>
              <td>
                <xsl:for-each select="exams/exam">
                  <div>
                    <strong>
                      <xsl:value-of select="name"/> :
                    </strong>
                    <span>
                      Tutor:
                      <xsl:value-of select="tutor"/> |
                    </span>
                    <span>
                      Score:
                      <xsl:value-of select="score"/>
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
