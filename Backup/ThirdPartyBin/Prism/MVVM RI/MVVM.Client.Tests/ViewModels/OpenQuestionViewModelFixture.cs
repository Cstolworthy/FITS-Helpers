//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM.Client.ViewModels;
using MVVM.Questionnaires.Model;
using MVVM.TestSupport;

namespace MVVM.Client.Tests.ViewModels
{
    [TestClass]
    public class OpenQuestionViewModelFixture
    {
        [TestMethod]
        public void WhenCreatingAViewModelWithANullQuestion_ThenAnExceptionIsThrown()
        {
            try
            {
                new OpenQuestionViewModel(null);
                Assert.Fail("should have thrown");
            }
            catch (ArgumentNullException)
            {
                // expected
            }
        }

        [TestMethod]
        public void ViewModelHasMaxLengthAsTheAvailableLength()
        {
            var question = new OpenQuestionTemplate { QuestionText = "Question", MaxLength = 25 }.CreateNewQuestion() as OpenQuestion;
            var viewModel = new OpenQuestionViewModel(question);

            Assert.AreEqual(25, viewModel.AvailableLength);
        }

        [TestMethod]
        public void WhenSettingTheResponseTextPropertyOnTheModel_ThenAvailableLengthIsUpdatedOnTheViewModel()
        {
            var question = new OpenQuestionTemplate { QuestionText = "Question", MaxLength = 25 }.CreateNewQuestion() as OpenQuestion;
            var viewModel = new OpenQuestionViewModel(question);

            question.Response = "1234567890";

            Assert.AreEqual(15, viewModel.AvailableLength);
        }

        [TestMethod]
        public void WhenSettingTheResponseTextPropertyOnTheModel_ThenAChangeOnAvailableLengthIsNotifiedOnTheViewModel()
        {
            var question = new OpenQuestionTemplate { QuestionText = "Question", MaxLength = 25 }.CreateNewQuestion() as OpenQuestion;
            var viewModel = new OpenQuestionViewModel(question);

            var changeTracker = new PropertyChangeTracker(viewModel);
            question.Response = "1234567890";

            Assert.IsTrue(changeTracker.ChangedProperties.Contains("AvailableLength"));
        }

        [TestMethod]
        public void WhenSettingTheResponseTextPropertyOnTheModel_ThenTheViewModelNotifiesAResponseChange()
        {
            var question = new OpenQuestionTemplate { QuestionText = "Question", MaxLength = 25 }.CreateNewQuestion() as OpenQuestion;
            var viewModel = new OpenQuestionViewModel(question);

            bool responseChanged = false;
            viewModel.ResponseChanged += (s, e) => responseChanged = true;
            question.Response = "1234567890";

            Assert.IsTrue(responseChanged);
        }

        [TestMethod]
        public void WhenCreatingTheViewModel_ThenHasChangesIsFalse()
        {
            var question = new OpenQuestionTemplate { QuestionText = "Question", MaxLength = 25 }.CreateNewQuestion() as OpenQuestion;
            var viewModel = new OpenQuestionViewModel(question);

            Assert.IsFalse(viewModel.HasChanges);
        }

        [TestMethod]
        public void WhenSettingTheResponseOntheModel_ThenViewModelHasChanges()
        {
            var question = new OpenQuestionTemplate { QuestionText = "Question", MaxLength = 25 }.CreateNewQuestion() as OpenQuestion;
            var viewModel = new OpenQuestionViewModel(question);

            question.Response = "1234567890";

            Assert.IsTrue(viewModel.HasChanges);
        }
    }
}
