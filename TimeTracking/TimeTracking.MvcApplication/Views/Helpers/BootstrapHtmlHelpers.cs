using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TimeTracking.MvcApplication.Views.Helpers
{

	#region Enums

	#region Bootstrap Grid Column

	public enum BootstrapGridColumn
	{
		ExtraSmall1,
		ExtraSmall2,
		ExtraSmall3,
		ExtraSmall4,
		ExtraSmall5,
		ExtraSmall6,
		ExtraSmall7,
		ExtraSmall8,
		ExtraSmall9,
		ExtraSmall10,
		ExtraSmall11,
		ExtraSmall12,
		Small1,
		Small2,
		Small3,
		Small4,
		Small5,
		Small6,
		Small7,
		Small8,
		Small9,
		Small10,
		Small11,
		Small12,
		Medium1,
		Medium2,
		Medium3,
		Medium4,
		Medium5,
		Medium6,
		Medium7,
		Medium8,
		Medium9,
		Medium10,
		Medium11,
		Medium12,
		Large1,
		Large2,
		Large3,
		Large4,
		Large5,
		Large6,
		Large7,
		Large8,
		Large9,
		Large10,
		Large11,
		Large12,
	}

	public static class BootstrapGridColumnEnumHelper
	{
		public static string GetBootstrapGridColumnString(BootstrapGridColumn gridColumn)
		{
			switch (gridColumn)
			{
				case BootstrapGridColumn.ExtraSmall1:
					return "col-xs-1";
				case BootstrapGridColumn.ExtraSmall2:
					return "col-xs-2";
				case BootstrapGridColumn.ExtraSmall3:
					return "col-xs-3";
				case BootstrapGridColumn.ExtraSmall4:
					return "col-xs-4";
				case BootstrapGridColumn.ExtraSmall5:
					return "col-xs-5";
				case BootstrapGridColumn.ExtraSmall6:
					return "col-xs-6";
				case BootstrapGridColumn.ExtraSmall7:
					return "col-xs-7";
				case BootstrapGridColumn.ExtraSmall8:
					return "col-xs-8";
				case BootstrapGridColumn.ExtraSmall9:
					return "col-xs-9";
				case BootstrapGridColumn.ExtraSmall10:
					return "col-xs-10";
				case BootstrapGridColumn.ExtraSmall11:
					return "col-xs-11";
				case BootstrapGridColumn.ExtraSmall12:
					return "col-xs-12";
				case BootstrapGridColumn.Small1:
					return "col-sm-1";
				case BootstrapGridColumn.Small2:
					return "col-sm-2";
				case BootstrapGridColumn.Small3:
					return "col-sm-3";
				case BootstrapGridColumn.Small4:
					return "col-sm-4";
				case BootstrapGridColumn.Small5:
					return "col-sm-5";
				case BootstrapGridColumn.Small6:
					return "col-sm-6";
				case BootstrapGridColumn.Small7:
					return "col-sm-7";
				case BootstrapGridColumn.Small8:
					return "col-sm-8";
				case BootstrapGridColumn.Small9:
					return "col-sm-9";
				case BootstrapGridColumn.Small10:
					return "col-sm-10";
				case BootstrapGridColumn.Small11:
					return "col-sm-11";
				case BootstrapGridColumn.Small12:
					return "col-sm-12";
				case BootstrapGridColumn.Medium1:
					return "col-md-1";
				case BootstrapGridColumn.Medium2:
					return "col-md-2";
				case BootstrapGridColumn.Medium3:
					return "col-md-3";
				case BootstrapGridColumn.Medium4:
					return "col-md-4";
				case BootstrapGridColumn.Medium5:
					return "col-md-5";
				case BootstrapGridColumn.Medium6:
					return "col-md-6";
				case BootstrapGridColumn.Medium7:
					return "col-md-7";
				case BootstrapGridColumn.Medium8:
					return "col-md-8";
				case BootstrapGridColumn.Medium9:
					return "col-md-9";
				case BootstrapGridColumn.Medium10:
					return "col-md-10";
				case BootstrapGridColumn.Medium11:
					return "col-md-11";
				case BootstrapGridColumn.Medium12:
					return "col-md-12";
				case BootstrapGridColumn.Large1:
					return "col-lg-1";
				case BootstrapGridColumn.Large2:
					return "col-lg-2";
				case BootstrapGridColumn.Large3:
					return "col-lg-3";
				case BootstrapGridColumn.Large4:
					return "col-lg-4";
				case BootstrapGridColumn.Large5:
					return "col-lg-5";
				case BootstrapGridColumn.Large6:
					return "col-lg-6";
				case BootstrapGridColumn.Large7:
					return "col-lg-7";
				case BootstrapGridColumn.Large8:
					return "col-lg-8";
				case BootstrapGridColumn.Large9:
					return "col-lg-9";
				case BootstrapGridColumn.Large10:
					return "col-lg-10";
				case BootstrapGridColumn.Large11:
					return "col-lg-11";
				case BootstrapGridColumn.Large12:
					return "col-lg-12";
				default:
					throw new ApplicationException("Unexpected BootstrapGridColumn enum value: " + gridColumn.ToString());
			}
		}
	}

	#endregion

	#region Bootstrap Form Type

	public enum BootstrapFormType
	{
		Default,
		Horizontal,
		Inline
	}

	public static class BootstrapFormTypeEnumHelper
	{
		public static string GetBootstrapFormString(BootstrapFormType formType)
		{
			switch (formType)
			{
				case BootstrapFormType.Default:
					return string.Empty;
				case BootstrapFormType.Horizontal:
					return "form-horizontal";
				case BootstrapFormType.Inline:
					return "form-inline";
				default:
					throw new ApplicationException("Unexpected BootstrapFormType enum value: " + formType.ToString());
			}
		}
	}

	#endregion

	#region Bootstrap Glyphicon Type

	public enum BootstrapGlyphiconType
	{
		Plus,
		StepBackward,
		StepForward
	}

	public static class BootstrapGlyphiconTypeEnumHelper
	{
		public static string GetBoostrapGlyphiconString(BootstrapGlyphiconType glyphiconType)
		{
			var glyphiconTypeString = "";

			switch (glyphiconType)
			{
				case BootstrapGlyphiconType.Plus:
					glyphiconTypeString = "plus";
					break;
				case BootstrapGlyphiconType.StepBackward:
					glyphiconTypeString = "step-backward";
					break;
				case BootstrapGlyphiconType.StepForward:
					glyphiconTypeString = "step-forward";
					break;
				default:
					throw new ApplicationException("Unexpected BootstrapGlyphiconType enum value: " + glyphiconType.ToString());
			}

			return "glyphicon-" + glyphiconTypeString;
		}
	}

	#endregion

	#region Bootstrap Button Size

	public enum BootstrapButtonSize
	{
		Default,
		ExtraSmall,
		Small,
		Large
	}

	public static class BootstrapButtonSizeEnumHelper
	{
		public static string GetBootstrapButtonSizeString(BootstrapButtonSize buttonSize)
		{
			switch (buttonSize)
			{
				case BootstrapButtonSize.Default:
					return string.Empty;
				case BootstrapButtonSize.ExtraSmall:
					return "btn-xs";
				case BootstrapButtonSize.Small:
					return "btn-sm";
				case BootstrapButtonSize.Large:
					return "btn-lg";
				default:
					throw new ApplicationException("Unexpected BootstrapButtonSize enum value: " + buttonSize.ToString());
			}
		}
	}

	#endregion

	#region Bootstrap Button Style

	public enum BootstrapButtonStyle
	{
		Default,
		Primary,
		Success,
		Info,
		Warning,
		Danger,
		Link
	}

	public static class BootstrapButtonStyleEnumHelper
	{
		public static string GetBootstrapButtonStyleString(BootstrapButtonStyle buttonStyle)
		{
			switch (buttonStyle)
			{
				case BootstrapButtonStyle.Default:
					return "btn-default";
				case BootstrapButtonStyle.Primary:
					return "btn-primary";
				case BootstrapButtonStyle.Success:
					return "btn-success";
				case BootstrapButtonStyle.Info:
					return "btn-info";
				case BootstrapButtonStyle.Warning:
					return "btn-warning";
				case BootstrapButtonStyle.Danger:
					return "btn-danger";
				case BootstrapButtonStyle.Link:
					return "btn-link";
				default:
					throw new ApplicationException("Unexpected BootstrapButtonStyle enum value: " + buttonStyle.ToString());
			}
		}
	}

	#endregion

	#endregion

	#region Form Group Class

	public class BootstrapFormGroup<TModel, TValue> : IDisposable
	{
		private bool _disposed;
		private ViewContext _context;

		//<div class="form-group">
		//	@Html.LabelFor(model => model.ProjectId, new { @class = "col-sm-2 control-label" })
		//	<div class="col-sm-10">
		//	</div>
		//</div>

		public BootstrapFormGroup(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> labelExpression,
			BootstrapGridColumn labelColumnSize, BootstrapGridColumn fieldColumnSize)
		{
			_context = html.ViewContext;

			_context.Writer.WriteLine("<div class=\"form-group\">");

			var labelClass = BootstrapGridColumnEnumHelper.GetBootstrapGridColumnString(labelColumnSize) + " control-label";
			var labelMvcString = html.LabelFor<TModel, TValue>(labelExpression, new { @class = labelClass });
			_context.Writer.WriteLine(labelMvcString);

			_context.Writer.WriteLine("<div class=\"{0}\">", BootstrapGridColumnEnumHelper.GetBootstrapGridColumnString(fieldColumnSize));
		}

		~BootstrapFormGroup()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				_context.Writer.WriteLine("</div></div>");
				_context.Writer.WriteLine();
			}

			_disposed = true;
		}
	}

	#endregion

	public static class BootstrapHtmlHelpers
	{

		#region Bootstrap Form Group

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="html"></param>
		/// <param name="labelExpression"></param>
		/// <param name="labelColumnSize"></param>
		/// <param name="fieldColumnSize"></param>
		/// <returns></returns>
		public static BootstrapFormGroup<TModel, TValue> BootstrapBeginFormGroup<TModel, TValue>(
			this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> labelExpression,
			BootstrapGridColumn labelColumnSize, BootstrapGridColumn fieldColumnSize)
		{
			return new BootstrapFormGroup<TModel,TValue>(html, labelExpression, labelColumnSize, fieldColumnSize);
		}

		#endregion

		#region Bootstrap Form

		/// <summary>
		/// Returns the markup for a Bootstrap form element.
		/// </summary>
		/// <param name="html">The instance of the HtmlHelper class.</param>
		/// <param name="method">The form method.</param>
		/// <param name="formType">The Bootstrap form type.</param>
		/// <returns>Returns a MvcHtmlString.</returns>
		public static MvcForm BootstrapBeginForm(this HtmlHelper html, FormMethod method = FormMethod.Post, 
			BootstrapFormType formType = BootstrapFormType.Default)
		{
			string currentController = html.ViewContext.RouteData.GetRequiredString("controller");
			string currentAction = html.ViewContext.RouteData.GetRequiredString("action");

			return html.BeginForm(currentAction, currentController, method, 
				new { role = "form", @class = BootstrapFormTypeEnumHelper.GetBootstrapFormString(formType) });
		}

		#endregion

		#region Bootstrap Glyphicons

		/// <summary>
		/// Returns the markup for a Bootstrap glyphicon.
		/// </summary>
		/// <param name="html">The instance of the HtmlHelper class.</param>
		/// <param name="glyphiconType">The glyphicon type.</param>
		/// <returns>Returns a MvcHtmlString.</returns>
		public static MvcHtmlString BootstrapGlyphicon(this HtmlHelper html, BootstrapGlyphiconType glyphiconType)
		{
			return MvcHtmlString.Create(GetBootstrapGlyphiconSpanString(glyphiconType));
		}

		private static string GetBootstrapGlyphiconSpanString(BootstrapGlyphiconType glyphiconType)
		{
			var spanBuilder = new TagBuilder("span");
			spanBuilder.AddCssClass("glyphicon");
			spanBuilder.AddCssClass(BootstrapGlyphiconTypeEnumHelper.GetBoostrapGlyphiconString(glyphiconType));

			return spanBuilder.ToString();
		}

		#endregion

		#region Bootstrap Button

		/// <summary>
		/// Returns the markup for a Bootstrap button (as an Html anchor tag).
		/// </summary>
		/// <param name="html">The instance of the HtmlHelper class.</param>
		/// <param name="buttonText">The button text.</param>
		/// <param name="actionName">The action name.</param>
		/// <param name="controllerName">The controller name.</param>
		/// <param name="glyphiconType">The glyphicon type.</param>
		/// <param name="isBlockLevel">Indicates whether or not the button should expand to fill the available width.</param>
		/// <param name="buttonStyle">The button style.</param>
		/// <param name="buttonSize">The button size.</param>
		/// <returns>Returns a MvcHtmlString.</returns>
		public static MvcHtmlString BootstrapLinkButton(this HtmlHelper html, string buttonText,
			string actionName, string controllerName,
			BootstrapGlyphiconType? glyphiconType = null,
			bool isBlockLevel = false,
			BootstrapButtonStyle buttonStyle = BootstrapButtonStyle.Default,
			BootstrapButtonSize buttonSize = BootstrapButtonSize.Default)
		{
			var url = new UrlHelper(html.ViewContext.RequestContext);
			var href = url.Action(actionName, controllerName);

			return GetBootstrapLinkButtonMvcHtmlString(buttonText, glyphiconType, isBlockLevel, 
				buttonStyle, buttonSize, href);
		}

		/// <summary>
		/// Returns the markup for a Bootstrap button (as an Html anchor tag).
		/// </summary>
		/// <param name="html">The instance of the HtmlHelper class.</param>
		/// <param name="buttonText">The button text.</param>
		/// <param name="routeName">The route name.</param>
		/// <param name="routeValues">The route values.</param>
		/// <param name="glyphiconType">The glyphicon type.</param>
		/// <param name="isBlockLevel">Indicates whether or not the button should expand to fill the available width.</param>
		/// <param name="buttonStyle">The button style.</param>
		/// <param name="buttonSize">The button size.</param>
		/// <returns>Returns a MvcHtmlString.</returns>
		public static MvcHtmlString BootstrapLinkButton(this HtmlHelper html, string buttonText,
			string routeName, object routeValues,
			BootstrapGlyphiconType? glyphiconType = null,
			bool isBlockLevel = false,
			BootstrapButtonStyle buttonStyle = BootstrapButtonStyle.Default,
			BootstrapButtonSize buttonSize = BootstrapButtonSize.Default)
		{
			var url = new UrlHelper(html.ViewContext.RequestContext);
			var href = url.RouteUrl(routeName, routeValues);

			return GetBootstrapLinkButtonMvcHtmlString(buttonText, glyphiconType, isBlockLevel, 
				buttonStyle, buttonSize, href);
		}

		private static MvcHtmlString GetBootstrapLinkButtonMvcHtmlString(string buttonText, 
			BootstrapGlyphiconType? glyphiconType, 
			bool isBlockLevel,
			BootstrapButtonStyle buttonStyle, 
			BootstrapButtonSize buttonSize, 
			string href)
		{
			var anchorBuilder = new TagBuilder("a");
			anchorBuilder.AddCssClass("btn");
			if (isBlockLevel)
			{
				anchorBuilder.AddCssClass("btn-block");
			}
			anchorBuilder.AddCssClass(BootstrapButtonStyleEnumHelper.GetBootstrapButtonStyleString(buttonStyle));
			// not every button size returns a value, so make sure that we've got a button size string
			// before adding a css class
			var buttonSizeString = BootstrapButtonSizeEnumHelper.GetBootstrapButtonSizeString(buttonSize);
			if (!string.IsNullOrWhiteSpace(buttonSizeString))
			{
				anchorBuilder.AddCssClass(buttonSizeString);
			}
			anchorBuilder.Attributes.Add("href", href);

			var glyphiconString = "";
			if (glyphiconType != null)
			{
				// add a space to the end of the span string 
				// to create some whitespace between the icon and the button text
				glyphiconString = GetBootstrapGlyphiconSpanString(glyphiconType.Value) + " ";
			}

			anchorBuilder.InnerHtml = glyphiconString + buttonText;

			return MvcHtmlString.Create(anchorBuilder.ToString());
		}

		#endregion

		#region Bootstrap Menu Item

		/// <summary>
		/// Returns the markup for a Bootstrap menu item.
		/// </summary>
		/// <param name="html">The instance of the HtmlHelper class.</param>
		/// <param name="linkText">The link text.</param>
		/// <param name="actionName">The action name.</param>
		/// <param name="controllerName">The controller name.</param>
		/// <returns>Returns a MvcHtmlString.</returns>
		public static MvcHtmlString BootstrapMenuItem(this HtmlHelper html, string linkText,
			string actionName, string controllerName)
		{
			var url = new UrlHelper(html.ViewContext.RequestContext);
			string currentController = html.ViewContext.RouteData.GetRequiredString("controller");

			var anchorBuilder = new TagBuilder("a");
			anchorBuilder.Attributes.Add("href", url.Action(actionName, controllerName));
			anchorBuilder.InnerHtml = linkText;

			var lineItemBuilder = new TagBuilder("li");
			if (controllerName == currentController)
				lineItemBuilder.AddCssClass("active");
			lineItemBuilder.InnerHtml = anchorBuilder.ToString();

			return MvcHtmlString.Create(lineItemBuilder.ToString());
		}

		#endregion

	}
}