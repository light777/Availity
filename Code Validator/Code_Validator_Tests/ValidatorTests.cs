using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Code_Validator_Tests
{
	[TestClass]
	public class ValidatorTests
	{
		[TestMethod]
		public void TestGoodCode()
		{
			var result = Code_Validator.Validator.CheckParanthesis(@"
				(defun csg-intersection-intersect-all (obj-a obj-b)
				 (lambda (ray)
					 (flet ((inside-p (obj) (lambda (d) (inside-p obj (ray-point ray d)))))
						 (merge 'fvector
										(remove-if-not (inside-p obj-b) (intersect-all obj-a ray))
										(remove-if-not (inside-p obj-a) (intersect-all obj-b ray))
										#'<))))
			");

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestBadCode()
		{
			var result = Code_Validator.Validator.CheckParanthesis(@"
				(defun csg-intersection-intersect-all (obj-a obj-b)
				 (lambda (ray)
					 (flet ((inside-p (obj) (lambda (d) (inside-p obj (ray-point ray d)))))
						 (merge 'fvector
										(remove-if-not (inside-p obj-b) (intersect-all obj-a ray))
										(remove-if-not (inside-p obj-a) (intersect-all obj-b ray))
										#'<))
			");

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestClosingParenBeforeOpeningParen()
		{
			var result = Code_Validator.Validator.CheckParanthesis(@"
				))(defun csg-intersection-intersect-all (obj-a obj-b)
				 (lambda (ray)
					 (flet ((inside-p (obj) (lambda (d) (inside-p obj (ray-point ray d)))))
						 (merge 'fvector
										(remove-if-not (inside-p obj-b) (intersect-all obj-a ray))
										(remove-if-not (inside-p obj-a) (intersect-all obj-b ray))
										#'<))))
			");

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void TestCodeWithComments()
		{
			var result = Code_Validator.Validator.CheckParanthesis(@"
				;; A mistake will increase by a factor of 3 while a correct answer
				;; will decrease by a factor of unity
				(defvar *mult-hyst* 3)
			");
		}

		[TestMethod]
		public void TestCodeWithParensInComments()
		{
			var result = Code_Validator.Validator.CheckParanthesis(@"
				;; A mistake will increase by a factor of 3) while a correct answer
				;; will decrease by a factor of unity
				(defvar *mult-hyst* 3)
			");
		}
	}
}
