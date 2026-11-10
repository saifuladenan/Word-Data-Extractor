<h1 align = 'Center'>Word Data Extractor</h1>
<p size = 8 align = 'Center'>
    An automated text extraction tool that dynamically generates search anchors to identify, retrieve, and organize          relevant information from large volumes of text files into structured Excel spreadsheets.
</p>

<h3>Introduction</h3>
<p size = 10 align = 'Justify'>
Word Data Extractor is an automated data extraction tool designed to process large volumes of text files. It dynamically generates search anchors to identify and retrieve relevant information, even when the source files contain minor formatting inconsistencies such as differences in spacing, line breaks, and text arrangement.
The extracted information is then organized and compiled into structured Excel spreadsheets for easier review, analysis, and reporting.
</p>

<h3>Problem Statement</h3>
<p size = 12 align = 'Justify'>
    Processing large text files manually can be time-consuming, repetitive, and prone to human error. Traditional            extraction methods may also depend on predefined keywords, fixed positions, or specific text structures.
</p>

<h3>Objective</h3>
<p size = 10 align = 'Justify'>
    To simplify and accelerate the process of extracting relevant information from large text files through dynamic          anchor generation and automated Excel data compilation, minimizing manual effort while improving productivity and        consistency.
</p>

<h3>Features</h3>
<p align="center">
  <img src="images/Word%20Data%20Extactor.png"
       width="80%"
       style="border: 1px solid #ccc; border-radius: 6px;"
       alt="Word Data Extractor Program Interface">
</p>

<p align="center">
  <em>Figure 4.1: Word Data Extractor Program Interface</em>
</p>
<br>
<p size="16" align="Justify">
    <b>Browse File</b>
</p>
<p size="10" align="Justify">
    Browse and select a folder directory. The system will automatically scan the selected directory and its subfolders to count the relevant files, including .doc, .docx, and .txt files.
</p>
<p align="center">
    <img src="images/Word-Data-Extractor browse.png"
         width="60%"
         style="border: 1px solid #ccc; border-radius: 6px;"
         alt="Word Data Extractor Browse Feature">
</p>
<p align="center">
    <em>Figure 4.1.1: Word Data Extractor Browse Feature</em>
</p>

<p size="16" align="Justify">
    <b>Generate Filter Option</b>
</p>
<p size="10" align="Justify">
    Enter a name for the filter. The specified name will be used as the column header in the generated results, making it easier to identify the extracted data in the DataGridView and exported file.
</p>
<p align="center">
         <img src="images/Word-Data-Extractor add filter.png"
         width="60%"
         style="border: 1px solid #ccc; border-radius: 6px;"
         alt="Word Data Extractor Generate Filter Option">
</p>
<p align="center">
    <em>Figure 4.1.2: Word Data Extractor Generate Filter Option</em>
</p>

<p size="16" align="Justify">
    <b>Filter Value</b>
</p>
<p size="10" align="Justify">
    <b>Search Value:</b> The keyword or text used as an anchor to locate the desired information in the document. (Required)<br>
    <b>Search Section:</b> Specifies the section or area of the document in which the system searches for the search value. (Optional)<br>
    <b>Filter Range Line:</b> Specifies the starting and ending lines to extract after the search value is matched. (Optional)<br>
    <b>Length:</b> Sets the maximum number of characters to return in the extracted result. (Optional)<br>
    <b>Regex:</b> Applies a Regular Expression (Regex) pattern to filter and extract specific data formats or text. (Optional)<br>
    <b>Include Search Text:</b> When checked, the matched search value is included in the extracted result. When unchecked, only the remaining text on the same line is returned, excluding the matched search value.<br>
    <b>Remove Button:</b> Removes the selected filter configuration.
</p>
<p align="center">
    <img src="images/Word-Data-Extractor filter.png"
         width="60%"
         style="border: 1px solid #ccc; border-radius: 6px;"
         alt="Word Data Extractor Filter Value">
</p>
<p align="center">
    <em>Figure 4.1.3: Word Data Extractor Filter Value</em>
</p>

<p size="16" align="Justify">
    <b>Filter Control Buttons</b>
</p>
<p size="10" align="Justify">
    <b>Reset Filter:</b> Removes all existing filter configurations from the filter panel. <br>
    <b>Filter Data:</b> Executes the configured filters, processes the selected documents, and displays the extracted results in the DataGridView (Figure 4.1.5). <br>
    <b>Export Data:</b> Exports the extracted results into an Excel file for further analysis and record-keeping. <br>
</p>
<p align="center">
    <img src="images/Word-Data-Extractor-button.png"
         width="60%"
         style="border: 1px solid #ccc; border-radius: 6px;"
         alt="Word Data Extractor Filter Control Buttons">
</p>
<p align="center">
    <em>Figure 4.1.4: Word Data Extractor Filter Control Buttons</em>
</p>


<p size="16" align="Justify">
    <b>Display Matched Data</b>
</p>
<p size="10" align="Justify">
    <b>1st Column (No.):</b> Displays the sequential number of each matched data record. <br>
    <b>2nd Column (File Name):</b> Displays the name of the document from which the data was extracted. <br>
    <b>Remaining Columns:</b> Display the extracted data based on the respective filter names and configurations.
</p>
<p align="center">
    <img src="images/Word-Data-Extractor data.png"
         width="60%"
         style="border: 1px solid #ccc; border-radius: 6px;"
         alt="Word Data Extractor Display Matched Data">
</p>
<p align="center">
    <em>Figure 4.1.5: Word Data Extractor Display Matched Data</em>
</p>

<p align="center">
  <img src="images/example doc.png"
       width="60%"
       style="border: 1px solid #ccc; border-radius: 6px;"
       alt="Example Source Document">
</p>
<p align="center">
  <em>Figure 4.2: Example Source Document</em>
</p>

<h3>Technologies Used</h3>
<p size="10" align="Justify">
    
<b>1. C# (Programming Language)</b><br>
    C# was used as the primary programming language to develop the application's functionality, including file reading, text extraction, filtering operations, and data processing.<br>
<b>2. Microsoft Visual Studio (Development Environment)</b><br>
    Microsoft Visual Studio was used as the Integrated Development Environment (IDE) for writing, debugging, testing, and building the application.<br>
<b>3. NPOI (Library)</b><br>
    NPOI is a .NET library that allows the application to read, process, and write Microsoft Office documents, including Word and Excel files.<br>
<b>4. NPOI.HWPF (Word Document Processing)</b><br>
    NPOI.HWPF is a component of NPOI used to read and extract text from Microsoft Word .doc files (older Word document format).<br>
<b>5. System.Text.Encoding.CodePages (Text Encoding Support)</b><br>
    This library provides support for additional character encodings, particularly legacy code pages. It allows the application to handle documents that use different text encodings and helps ensure proper text extraction.
</p>

<h3>Limitations</h3>
<p size = 10 align = 'Justify'>
</p>
<h3>Future Improvements</h3>
<p size = 10 align = 'Justify'>
</p>
<h3>Author / Developer</h3>
<p size = 10 align = 'Center'>
    SaifulAdenan
</p>




