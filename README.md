﻿<Project ToolsVersion="14.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <!-- Import the common properties to support NuGet restore -->
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <!-- The configuration and platform will be used to determine which assemblies to include from solution and
				 project documentation sources -->
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{cdc736ce-cef4-4bd2-a358-f82714378593}</ProjectGuid>
    <SHFBSchemaVersion>2017.9.26.0</SHFBSchemaVersion>
    <!-- AssemblyName, Name, and RootNamespace are not used by SHFB but Visual Studio adds them anyway -->
    <AssemblyName>Documentation</AssemblyName>
    <RootNamespace>Documentation</RootNamespace>
    <Name>Documentation</Name>
    <!-- SHFB properties -->
    <FrameworkVersion>.NET Core/.NET Standard/.NET 5.0+</FrameworkVersion>
    <OutputPath>.\Help\</OutputPath>
    <HtmlHelpName>Documentation</HtmlHelpName>
    <Language>en-US</Language>
    <DocumentationSources>
      <DocumentationSource sourceFile="CarDealership\bin\x64\Debug\CarDealership.XML" />
<DocumentationSource sourceFile="CarDealership\bin\x64\Debug\CarDealership.exe" /></DocumentationSources>
    <HelpFileFormat>HtmlHelp1</HelpFileFormat>
    <SyntaxFilters>Standard</SyntaxFilters>
    <PresentationStyle>VS2013</PresentationStyle>
    <CleanIntermediates>True</CleanIntermediates>
    <KeepLogFile>True</KeepLogFile>
    <DisableCodeBlockComponent>False</DisableCodeBlockComponent>
    <IndentHtml>False</IndentHtml>
    <BuildAssemblerVerbosity>OnlyWarningsAndErrors</BuildAssemblerVerbosity>
    <SaveComponentCacheCapacity>100</SaveComponentCacheCapacity>
  </PropertyGroup>
  <!-- There are no properties for these groups.  AnyCPU needs to appear in order for Visual Studio to perform
			 the build.  The others are optional common platform types that may appear. -->
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|x86' ">
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|x86' ">
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|x64' ">
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|x64' ">
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|Win32' ">
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|Win32' ">
  </PropertyGroup>
  <!-- Import the common build targets during NuGet restore because before the packages are being installed, $(SHFBROOT) is not set yet -->
  <Import Project="$(MSBuildToolsPath)\Microsoft.Common.targets" Condition="'$(MSBuildRestoreSessionId)' != ''" />
  <!-- Import the SHFB build targets during build -->
  <Import Project="$(SHFBROOT)\SandcastleHelpFileBuilder.targets" Condition="'$(MSBuildRestoreSessionId)' == ''" />
  <!-- The pre-build and post-build event properties must appear *after* the targets file import in order to be
			 evaluated correctly. -->
  <PropertyGroup>
    <PreBuildEvent>
    </PreBuildEvent>
    <PostBuildEvent>
    </PostBuildEvent>
    <RunPostBuildEvent>OnBuildSuccess</RunPostBuildEvent>
  </PropertyGroup>
</Project>