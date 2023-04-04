    using LINQSamples;

    // Create instance of view model
    SamplesViewModel vm = new();

    try
    {

    // Call Sample Method
    var result = vm.ForEachQueryCallingMethod();
        // Display Results
        vm.Display(result);
    }
    catch (ArgumentNullException ex)
    {
        vm.Display(ex);
    }
    catch (InvalidOperationException ex)
    {
        vm.Display(ex);
    }


