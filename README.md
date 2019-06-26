# Semi-Automated-Code-Testing-Environment

SERVICE ORIENTED ARCHITECTURE | ASP.NET | WCF SERVICES

• A tool that performs unit testing for standalone code or functions.

• This tool is completely based on Service Oriented Architecture and is designed with utmost loose coupling.

• This tools works on time based threshold and continuosly checks the output of absolutely correct code and code that is being tested.

• The backend Services can be consumed platform independently hence incorporating reusability and extensibility.

• Follows all the SOA principles.

• Further Extension to project can include development in the field of code sysnthesis, or using data analytics to make test generation more intellegent instead of probabilistic.

# Run the Tool

• All the hosts are console Application.

• First Run ServiceHost (Host for CodeExecuter Service).

• Then Run ServiceHostCoordinator (Host for CodeCoordination Service). This Service controls Workflow.

• Now Run the client MVC.

• The Client takes 3 files as Input

	1. Tester File (This is supposedly Correct code, Hence Primary Code).
	2. Testing File (This needs to be tested for Correctness Hence Secondary Code).
	3. Test Generation File (This File Generates Input for Above Two Codes).

	# Note: It is possible to give Whole Folder for Testing. Hence Argument 2 can be a file or a Folder of Multiple Files.

• Corresponding Verdict Files are generated and they can be used for Correction if any.